using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaTI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace SistemaTI.Controllers
{

    [Authorize(Roles = "SuperAdmin")]

    public class GerenciamentoUsuariosController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GerenciamentoUsuariosController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        private async Task<List<string>> PegarUsuarioRegra(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var UsuarioRegraViewModel = new List<UsuarioRegraViewModel>();
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UsuarioRegraViewModel();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.PrimeiroNome = user.PrimeiroNom;
                thisViewModel.Sobrenome = user.SobreNom;
                thisViewModel.Regra = await PegarUsuarioRegra(user);
                UsuarioRegraViewModel.Add(thisViewModel);
            }
            return View(UsuarioRegraViewModel);
        }

        // Adição do Usuário a Regra

        public async Task<IActionResult> Gerenciar(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;
            var model = new List<GerenciamentoRegraUsuarioViewModel>();
            foreach (var role in _roleManager.Roles.ToList())
            {
                var userRolesViewModel = new GerenciamentoRegraUsuarioViewModel
                {
                    RegraId = role.Id,
                    RegraNome = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selecao = true;
                }
                else
                {
                    userRolesViewModel.Selecao = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Gerenciar(List<GerenciamentoRegraUsuarioViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selecao).Select(y => y.RegraNome));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("Index");
        }

        // Deletar Usuário
        /* referencias 
         * https://csharp-video-tutorials.blogspot.com/2019/08/delete-identity-user-in-aspnet-core.html
         * https://www.yogihosting.com/aspnet-core-identity-create-read-update-delete-users/
         */
        [HttpPost]
        public async Task<IActionResult> DeletarUsuario(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuário de ID: {userId} não localizado";
                return View("NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("Index");
            }
        }

        // Index das regras
        public async Task<IActionResult> Regra()
        {
            var regras = await _roleManager.Roles.ToListAsync();
            return View(regras);
        }

        // Adição de regras/Nivel de acesso 
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("Regra"); // Retorna para lista de regras
        }
    }
}