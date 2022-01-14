﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTI.Models
{
    public class Usuario : IdentityUser
    {
        [PersonalData]
        public string PrimeiroNome { get; set; }
        
        [PersonalData]
        public string SobrenomeNome { get; set; }
        public int LimiteMudanca { get; set; } = 10;
        public byte[] FotoPerfil { get; set;}
    }
}
