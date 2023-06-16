public class Administrativo : Funcionario
{
    public string funcao { get; set; }

    public Administrativo(string funcao, string nome, string cpf, string matricula, string dataNascimento, string sexo, double salario) 
    {
        this.funcao = funcao;
        this.nome = nome;
        this.cpf = cpf;
        this.matricula = matricula;
        this.dataNascimento = dataNascimento;
        this.sexo = sexo;
        this.salario = salario;
    }

    public double CalcularBeneficioAdministrativo()
    {
        return (salario * 0.15) + 150;
    }
}
