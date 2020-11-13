namespace WebApiOdata.Models
{
    public class Contato
    {
        public int id {get; set;}
        public int pessoaid { get; set; }

        public string pessoanome { get; set; }
        public string pessoasobrenome { get; set; }
        public string nomeusuario { get; set; }
        
        public string endereco { get; set; }

    }
}