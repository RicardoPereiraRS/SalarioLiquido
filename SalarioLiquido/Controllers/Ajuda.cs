using Microsoft.AspNetCore.Mvc;

namespace SalarioLiquido.Controllers
{
    [Route("[controller]")]
	[ApiController]
	public class Ajuda : ControllerBase	
	{

		public string get()
		{
			return "PARAMETROS DA API, EXEMPLO: https://salarioliquido/calcular?salariobruto=3500&outrosdescontos=320.45&dependentes=2";

		}

	}
}
