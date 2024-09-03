using Microsoft.AspNetCore.Mvc;
using TesteB3.Models;

namespace TesteB3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CdbController : ControllerBase
    {
        [HttpPost("calcular")]
        public IActionResult CalcularCdb([FromBody]CalculoCdb request)
        {
            if (ModelState.IsValid)
            {
                if (request.ValorInvestido <= 0 || request.PrazoMeses <= 1)
                {
                    return BadRequest("O valor investido deve ser positivo e o prazo deve ser maior que 1 mês.");
                }

                decimal taxaBanco = 1.08m; 
                decimal taxaCdi = 0.009m; 

                // Cálculo do CDB mês a mês
                decimal rendimentoBruto = request.ValorInvestido;
                decimal impostoDeRenda = 0;

                for (int i = 0; i < request.PrazoMeses; i++)
                {
                    decimal rendimentoMensal = rendimentoBruto * (taxaCdi * taxaBanco);
                    impostoDeRenda += rendimentoMensal * ObterAliquotaImposto(i + 1);
                    rendimentoBruto += Math.Round(rendimentoMensal,2);
                }

                decimal rendimentoLiquido = rendimentoBruto - impostoDeRenda;

                var resultado = new CalculoCdbResponse
                {
                    RendimentoBruto = rendimentoBruto - request.ValorInvestido,
                    RendimentoLiquido = Math.Round(rendimentoLiquido - request.ValorInvestido, 2),
                    ValorTotalBruto = rendimentoBruto,
                    ValorInvestido = Math.Round(request.ValorInvestido, 2),
                    PrazoMeses = request.PrazoMeses
                };

                return Ok(resultado);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private decimal ObterAliquotaImposto(int meses)
        {
            if (meses <= 6)
            {
                return 0.225m; 
            }
            else if (meses <= 12)
            {
                return 0.20m; 
            }
            else if (meses <= 24)
            {
                return 0.175m; 
            }
            else
            {
                return 0.15m; 
            }
        }
    }
}