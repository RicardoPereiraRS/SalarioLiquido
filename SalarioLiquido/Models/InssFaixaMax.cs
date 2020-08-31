using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalarioLiquido.Models
{
    public class InssFaixaMax:InssBase
    {
        public override decimal CalcularInss(decimal salarioBruto)
        {
            return 713.1m;
        }
    }
}
