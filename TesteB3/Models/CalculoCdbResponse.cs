using System;
using System.ComponentModel.DataAnnotations;

namespace TesteB3.Models
{
    public class CalculoCdbResponse
    {

        public decimal RendimentoBruto { get; set; }
        public decimal RendimentoLiquido { get; set; }
        public decimal ValorTotalBruto { get; set; }
        public decimal ValorInvestido { get; set; }
        public int PrazoMeses { get; set; }

    }
}
