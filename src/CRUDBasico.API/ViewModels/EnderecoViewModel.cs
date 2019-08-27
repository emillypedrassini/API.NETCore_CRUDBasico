using System.ComponentModel.DataAnnotations;

namespace CRUDBasico.API.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public int Id { get; private set; }
        //public int FuncionarioId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        //[ScaffoldColumn(false)]
        //public FuncionarioViewModel Funcionario { get; set; }
    }
}
