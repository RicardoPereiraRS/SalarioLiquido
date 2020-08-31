using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalarioLiquido.Models
{
    public class InssFaixa4 : InssBase
    {
        public override decimal CalcularInss(decimal salarioBruto)
        {
            //decimal desconto = (1045m * 0.075m) +
            //   (1044.6m * 0.09m) +
            //   (1044.8m * 0.12m) +
            //   ((salarioBruto - 3134.4m) * 0.14m);

            decimal desconto = 297.765m + ((salarioBruto - 3134.4m) * 0.14m);

            return desconto;

               

        }
    }
}
