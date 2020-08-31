namespace SalarioLiquido.Models
{
    public interface ICalculoSalario
    {
        decimal CalcularInss(decimal salario);

        decimal CalcularIrrf(decimal rendimentos, int dependentes);

       

    }
}
