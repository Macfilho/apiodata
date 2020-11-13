using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiOdata.Models;

namespace WebApiOdata.Contextopessoa
{
    public class contexto :DbContext
    {
        public DbSet <Pessoa> Pessoa { get; set; }
        public DbSet <Contato> Contato { get; set; }
    }
}