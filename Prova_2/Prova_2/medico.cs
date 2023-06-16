sealed public class Medico : Funcionario
{
    public string crm { get; set; }

    public double valorHoraExtra { get; set; }

    public string especialidade { get; set; }

    public Medico(string crm, double valorHoraExtra, string especialidade, string nome, string cpf, string matricula, string dataNascimento, string sexo, double salario)
    {
        this.crm = crm;
        this.valorHoraExtra = valorHoraExtra;
        this.especialidade = especialidade;
        this.nome = nome;
        this.cpf = cpf;
        this.matricula = matricula;
        this.dataNascimento = dataNascimento;
        this.sexo = sexo;
        this.salario = salario;
    }

    public double CalcularBeneficioMedico()
    {
        return salario * 0.2;
    }
}