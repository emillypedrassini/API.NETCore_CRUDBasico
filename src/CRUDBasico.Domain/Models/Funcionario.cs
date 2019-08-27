using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRUDBasico.Domain.Models
{
    public class Funcionario
    {
        public int Id { get; private set; }

        public string Nome { get; set; }

        public string Funcao { get; set; }

        public string Salario { get; set; }

        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataAdmissao { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        /* EF Relation */
        public Endereco Endereco { get; set; }

    }
}
