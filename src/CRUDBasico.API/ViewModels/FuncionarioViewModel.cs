using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBasico.API.ViewModels
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Funcao { get; set; }

        public string Salario { get; set; }

        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataAdmissao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        /* EF Relation */
        //public EnderecoViewModel Endereco { get; set; }
    }
}
