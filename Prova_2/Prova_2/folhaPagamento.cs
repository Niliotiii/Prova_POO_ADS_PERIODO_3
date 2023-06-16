public class FolhaPagamento
{
    public string mes { get; set; }
    public Funcionario funcionario { get; set; }
    public double valorIrpf { get; set; }
    public double qtdHorasExtra { get; set; }

    public double valorPagamento { get; set; }

    public static double valorFolhaPagamento;

    public double CalcularValorPagamento()
    {

        if (funcionario is Medico)
        {
            Medico medico = (Medico) funcionario;
            valorPagamento = medico.salario + medico.CalcularBeneficioMedico() + (qtdHorasExtra*medico.valorHoraExtra);
            if (medico.salario > 5000)
            {
                valorPagamento = valorPagamento - ((medico.salario + medico.CalcularBeneficioMedico()) *0.17);
            }
        }
        else if (funcionario is Administrativo) 
        {
            Administrativo administrativo = (Administrativo) funcionario;
            valorPagamento = administrativo.salario + administrativo.CalcularBeneficioAdministrativo();
            if (administrativo.salario > 5000)
            {
                valorPagamento = valorPagamento * 0.83;
            }
        }

        valorFolhaPagamento += valorPagamento;
        return valorPagamento;
    }

    public double GetValorFolhaPagamento()
    {
        return valorFolhaPagamento;
    }

    public static double VerificarValorGastoMes(List<FolhaPagamento> folhasPagamento, string mes)
    {
        double aux = 0;
        foreach (var folhaPag in folhasPagamento)
        {
            if (folhaPag.mes == mes)
            {
                aux = folhaPag.GetValorFolhaPagamento();
            }
        }
        return aux;
    }
}