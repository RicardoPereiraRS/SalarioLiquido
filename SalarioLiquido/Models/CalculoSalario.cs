using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SalarioLiquido.Models
{
    public class CalculoSalario : ICalculoSalario
    {

        // fonte para base de cálculos:
        //  https://www.todacarreira.com/calculo-salario-liquido/?value=&dependents=&otherdiscounts=#salary-simulator


        public decimal CalculaInss(decimal salario)
        {
            decimal descontoInss = 0;

            if (salario <= 1045m)
            {
                descontoInss = CalculaInssFaixa1(salario);
            }

            else if (salario >= 1045.01m && salario <= 2089.60m)
            {
                descontoInss = CalculaInssFaixa2(salario);
            }

            else if (salario >= 2089.61m && salario <= 3134.40m)
            {
                descontoInss = CalculaInssFaixa3(salario);
            }

            else if (salario >= 3134.41m && salario <= 6101.06m)
            {
                descontoInss = CalculaInssFaixa4(salario);
            }

            else if (salario > 6101.06m)
            {
                descontoInss = CalculaInssFaixaMax();
            }

            return descontoInss;
        }

        public decimal CalculaIrrf(decimal rendimentos, int dependentes)
        {
            // desconta o valor dos dependentes ao rendimento
            rendimentos = rendimentos - (dependentes * 189.59m);

            if (rendimentos <= 1903.98m)
            {
                return 0;
            }

            decimal indice = 0;
            decimal deducao = 0;

            if (rendimentos >= 1903.99m && rendimentos <= 2826.65m)
            {
                indice = 0.075m;
                deducao = 142.8m;
            }

            else if (rendimentos >= 2826.66m && rendimentos <= 3751.05m)
            {
                indice = 0.15m;
                deducao = 354.8m;
            }

            else if (rendimentos >= 3751.06m && rendimentos <= 4664.68m)
            {
                indice = 0.225m;
                deducao = 636.13m;
            }

            else if (rendimentos > 4664.68m)
            {
                indice = 0.275m;
                deducao = 869.36m;
            }

            // calcula e desconta a dedução conforme a faixa de rendimento.

            decimal valorIrrf = (indice * rendimentos) - deducao;

            // não pode ter valor de desconto irrf menor que zero.
            if (valorIrrf < 0)
            {
                valorIrrf = 0;
            }

            return valorIrrf;
        }

       public decimal CalculaInssFaixa1(decimal salarioBruto)
        {
            return salarioBruto * 0.075m;
        }

        public decimal CalculaInssFaixa2(decimal salarioBruto)
        {
            decimal desconto = 1045m * 0.075m +
                (salarioBruto - 1045m) * 0.09m;

            return desconto;
        }

        public decimal CalculaInssFaixa3(decimal salarioBruto)
        {
            decimal desconto = (1045m * 0.075m) +
                (1044.6m * 0.09m) +
                ((salarioBruto - 2089.6m) * 0.12m);

            return desconto;
        }

        public decimal CalculaInssFaixa4(decimal salarioBruto)
        {
            decimal desconto = (1045m * 0.075m) +
                (1044.6m * 0.09m) +
                (1044.8m * 0.12m) +
                ((salarioBruto - 3134.4m) * 0.14m);

            return desconto;
        }

        public decimal CalculaInssFaixaMax()
        {
            return 713.1m;
        }
    }
}
