List<FolhaPagamento> folhasPagamento = new List<FolhaPagamento>();

try
{
    Console.Write("Quantos funcionários deseja cadastrar? ");
    int quantidadeFuncionarios;

    while (!int.TryParse(Console.ReadLine(), out quantidadeFuncionarios) || quantidadeFuncionarios <= 0)
    {
        Console.WriteLine("Quantidade inválida. Digite um número inteiro maior que 0.");
    }

    for (int i = 0; i < quantidadeFuncionarios; i++)
    {
        int oqueDesejaCadastrar;

        while (true)
        {
            Console.Write("Escolha o que deseja cadastrar:\n" +
                "1- Médico\n" +
                "2- Administrativo\n" +
                "Opção: ");

            if (int.TryParse(Console.ReadLine(), out oqueDesejaCadastrar) && (oqueDesejaCadastrar == 1 || oqueDesejaCadastrar == 2))
            {
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Digite 1 para Médico ou 2 para Administrativo.");
            }
        }

        string nome, cpf, matricula, dataNascimento, sexo;
        double salario;

        Console.Write("Nome: ");
        nome = Console.ReadLine();

        Console.Write("CPF: ");
        cpf = Console.ReadLine();

        Console.Write("Matrícula: ");
        matricula = Console.ReadLine();

        Console.Write("Data de Nascimento: ");
        dataNascimento = Console.ReadLine();

        Console.Write("Sexo: ");
        sexo = Console.ReadLine();

        while (true)
        {
            try
            {
                Console.Write("Salário: ");
                salario = double.Parse(Console.ReadLine());

                if (salario <= 0)
                    throw new Exception("Valor inválido. Digite um número maior que 0.");

                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Valor inválido. Digite um número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        if (oqueDesejaCadastrar == 1)
        {
            string crm, especialidade;
            double valorHoraExtra;

            Console.Write("CRM: ");
            crm = Console.ReadLine();

            Console.Write("Especialidade: ");
            especialidade = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.Write("Valor da Hora Extra: ");
                    valorHoraExtra = double.Parse(Console.ReadLine());

                    if (valorHoraExtra < 0)
                        throw new Exception("Valor inválido. Digite um número maior ou igual a 0.");

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valor inválido. Digite um número válido.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Medico medico = new Medico(crm, valorHoraExtra, especialidade, nome, cpf, matricula, dataNascimento, sexo, salario);
            Funcionario funcionario = medico;
            FolhaPagamento folhaPagamento = new FolhaPagamento
            {
                mes = "Janeiro",
                funcionario = funcionario,
                qtdHorasExtra = 10
            };
            folhasPagamento.Add(folhaPagamento);
        }
        else if (oqueDesejaCadastrar == 2)
        {
            string funcao;

            Console.Write("Função: ");
            funcao = Console.ReadLine();

            Administrativo administrativo = new Administrativo(funcao, nome, cpf, matricula, dataNascimento, sexo, salario);
            Funcionario funcionario = administrativo;
            FolhaPagamento folhaPagamento = new FolhaPagamento
            {
                mes = "Janeiro",
                funcionario = funcionario
            };
            folhasPagamento.Add(folhaPagamento);
        }
    }

    Console.Clear();

    foreach (FolhaPagamento folha in folhasPagamento)
    {
        Console.WriteLine($"Mês: {folha.mes}");
        Console.WriteLine($"Nome: {folha.funcionario.nome}");
        Console.WriteLine($"CPF: {folha.funcionario.cpf}");
        Console.WriteLine($"Matrícula: {folha.funcionario.matricula}");
        Console.WriteLine($"Data de Nascimento: {folha.funcionario.dataNascimento}");
        Console.WriteLine($"Sexo: {folha.funcionario.sexo}");
        Console.WriteLine($"Salário: {folha.funcionario.salario}");
        Console.WriteLine($"Valor do Pagamento: {folha.CalcularValorPagamento()}");
        Console.WriteLine();
    }

    string mesConsulta = "Janeiro";
    double valorGastoMes = FolhaPagamento.VerificarValorGastoMes(folhasPagamento, mesConsulta);
    Console.WriteLine($"O valor gasto no mês de {mesConsulta} é de R${valorGastoMes}");
}
catch (Exception ex)
{
    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
}

Console.ReadKey();