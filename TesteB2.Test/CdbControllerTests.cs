using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;
using TesteB3.Controllers;
using TesteB3.Models;

namespace TesteB2.Test
{
    [TestFixture]
    public class CdbControllerTests
    {
        private CdbController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new CdbController();
        }

        [Test]
        public void CalculateInvestment_ShouldReturnCorrectResults()
        {
            decimal initialValue = 1000;
            int months = 6;

            var result = _controller.CalcularCdb( new CalculoCdb(){
                ValorInvestido = initialValue,
                PrazoMeses = months
            });

            var okResult = result as OkObjectResult;

            // Verificar se o resultado é Ok e se o valor não é nulo
            Assert.NotNull(okResult);
            Assert.NotNull(okResult.Value);

            var calcResult = okResult.Value as CalculoCdbResponse;

            Assert.That(calcResult.ValorTotalBruto, Is.EqualTo(1059.75), "O rendimento bruto deve ser 1059.75");
            Assert.That(calcResult.RendimentoBruto, Is.EqualTo(59.75), "O Rendimento líquido deve ser 59.75");
        }
    }
}