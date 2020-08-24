using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalarioLiquido.Models
{
    public interface ICalculoSalario
    {
        decimal CalculaInss(decimal salario);

        decimal CalculaIrrf(decimal rendimentos, int dependentes);

        decimal CalculaInssFaixa1(decimal salarioBruto);

        decimal CalculaInssFaixa2(decimal salarioBruto);

        decimal CalculaInssFaixa3(decimal salarioBruto);

        decimal CalculaInssFaixa4(decimal salarioBruto);

        decimal CalculaInssFaixaMax();

    }
}
