using Microsoft.AspNetCore.Mvc;
using SalarioLiquido.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalarioLiquido.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Calcular : ControllerBase
    {
        private readonly ICalculoSalario calculo;

        public Calcular(ICalculoSalario calculo)
        {
            this.calculo = calculo;
        }

        [HttpGet]
        public JsonResult Get(decimal salarioBruto, decimal outrosDescontos, int dependentes)
        {

            decimal descInss = calculo.CalculaInss(salarioBruto);

            decimal descIrrf = calculo.CalculaIrrf(salarioBruto - descInss, dependentes);

            decimal totalDescontos = descInss + descIrrf + outrosDescontos;

            decimal salarioLiquido = salarioBruto - totalDescontos;

            return new JsonResult(new
            {
                salarioBruto = salarioBruto,
                descontoInss = descInss,
                descontoIrrf = descIrrf,
                outrosDescontos = outrosDescontos,
                totalDescontos = totalDescontos,
                salarioLiquido = salarioLiquido
            });
        }
    }
}
