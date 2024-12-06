namespace IRibeiroAPI.Infrastructure.Crosscutting.Helpers;

public class TimeHelper
{
    public static string CalcularTempoPublicado(DateTime dataPublicacao)
    {
        var dataAtual = DateTime.Now;
        var diferenca = dataAtual - dataPublicacao;

        if (diferenca.Days < 30)
        {
            return $"{diferenca.Days} dia(s)";
        }
        else if (diferenca.Days < 365)
        {
            int meses = diferenca.Days / 30;
            return $"{meses} mês(es)";
        }
        else
        {
            int anos = diferenca.Days / 365;
            return $"{anos} ano(s)";
        }
    }
}
