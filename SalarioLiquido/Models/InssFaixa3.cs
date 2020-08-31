using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalarioLiquido.Models
{
    public class InssFaixa3 : InssBase
    {
        public override decimal CalcularInss(decimal salarioBruto)
        {
            //decimal desconto = (1045m * 0.075m) +
            //    (1044.6m * 0.09m) +
            //    ((salarioBruto - 2089.6m) * 0.12m);

            decimal desconto = 172.389m + ((salarioBruto - 2089.6m) * 0.12m);

            return desconto;
        }
    }
}
