using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalarioLiquido.Models
{
    public class InssFaixa1 : InssBase
    {
        public override decimal CalcularInss(decimal salarioBruto)
        {
            return salarioBruto * 0.075m;
        }

    }
}
