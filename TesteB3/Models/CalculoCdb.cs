using System;
using System.ComponentModel.DataAnnotations;

namespace TesteB3.Models
{
    public class CalculoCdb
    {

        [Required(ErrorMessage = "Campo obrigatório" )]
        public decimal ValorInvestido { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int PrazoMeses { get; set; }

    }
}
