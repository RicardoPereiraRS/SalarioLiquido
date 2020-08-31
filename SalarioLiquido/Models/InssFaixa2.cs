using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalarioLiquido.Models
{
    public class InssFaixa2 : InssBase
    {
        public override decimal CalcularInss(decimal salarioBruto)
        {
            //decimal desconto = 1045m * 0.075m +
            //    (salarioBruto - 1045m) * 0.09m;

            decimal desconto = 78.375m + ((salarioBruto - 1045m) * 0.09m);

            return desconto;
        }
    }
}
