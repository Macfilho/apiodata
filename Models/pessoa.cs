using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOdata.Models
{
    public class Pessoa
    {
        public int id { get; set;}
        public string nome { get; set;}
        public string sobrenome { get; set;}
        public string nomeusuario { get; set;}
        public string endereco { get; set; }

        public virtual List<Contato> Contatos { get; set; }

    }
}