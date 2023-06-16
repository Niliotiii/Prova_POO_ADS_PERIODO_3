public abstract class Funcionario
{
    public string nome { get; set; }
    public string cpf { get; set;}
    public string matricula { get; set;}

    public string dataNascimento { get; set; }

    public string sexo { get; set; }
    public double salario { get; set; }

    /* public Funcionario( string nome, string cpf, string matricula, string dataNascimento, string sexo, double salario) 
    {
        this.nome = nome;
        this.cpf = cpf;
        this.matricula = matricula;
        this.dataNascimento = dataNascimento;
        this.sexo = sexo;
        this.salario = salario;
    }*/
}