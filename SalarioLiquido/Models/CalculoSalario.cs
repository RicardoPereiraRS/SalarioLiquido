using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace SalarioLiquido.Models
{
    public class CalculoSalario : ICalculoSalario
    {

        // fonte para base de cálculos:
        //  https://www.todacarreira.com/calculo-salario-liquido/?value=&dependents=&otherdiscounts=#salary-simulator


        public decimal CalcularInss(decimal salarioBruto)
        {

            InssBase[] inssFaixas = {new InssFaixa1(),new InssFaixa2(),
                new InssFaixa3(), new InssFaixa4(),new InssFaixaMax()};

            decimal[] faixasSalrio = { 1045.01m, 2089.61m, 3134.41m, 6101.07m };

            int i;
            for (i = 0; i < faixasSalrio.Length; i++)
            {
                if (salarioBruto < faixasSalrio[i])
                {
                    break;
                }
            }

            return inssFaixas[i].CalcularInss(salarioBruto);
        }

        public decimal CalcularIrrf(decimal rendimentos, int dependentes)
        {
            // desconta o valor dos dependentes ao rendimento
            rendimentos = rendimentos - (dependentes * 189.59m);

            decimal[] faixasSalario = { 1093.99m, 2826.66m, 3751.06m, 4664.69m };

            decimal[] parcelasDedutiveis = { 0, 142.8m, 354.8m, 636.13m, 869.36m };

            decimal[] aliquotas = { 0, 0.075m, 0.15m, 0.225m, 0.275m };

            int i;

            for (i = 0; i < faixasSalario.Length; i++)
            {
                if (rendimentos < faixasSalario[i])
                {
                    break;
                }
            }

            // calcula e desconta a dedução conforme a faixa de rendimento.
            decimal valorIrrf = (aliquotas[i] * rendimentos) - parcelasDedutiveis[i];


            // desconto irrf não pode ser menor que zero
            if (valorIrrf < 0)
            {
                valorIrrf = 0;
            }

            return valorIrrf;
        }
    }
}
