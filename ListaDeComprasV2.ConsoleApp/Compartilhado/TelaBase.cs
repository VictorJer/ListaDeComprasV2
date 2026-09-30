
using ListaDeComprasV2.ConsoleApp.Compartilhado.Arquivos;
using ListaDeComprasV2.ConsoleApp.Utilidade;

namespace ListaDeComprasV2.ConsoleApp.Compartilhado;

public abstract class TelaBase<T> where T : EntidadeBase
{
    public string nomeEntidade = string.Empty;
    protected IRepositorio<T> repositorio;

    protected TelaBase(string nomeEntidade, IRepositorio<T> repositorio)
    {
        this.nomeEntidade = nomeEntidade;
        this.repositorio = repositorio;
    }

    public virtual string? ObterOpcaoMenu()
    {
        string nomeMinusculo = nomeEntidade.ToLower();

        // Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestão de {nomeEntidade}");
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"1 - Cadastrar {nomeMinusculo}");
        Console.WriteLine($"2 - Editar {nomeMinusculo}");
        Console.WriteLine($"3 - Excluir {nomeMinusculo}");
        Console.WriteLine($"4 - Visualizar {nomeMinusculo}s");
        Console.WriteLine("S - Voltar para o início");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    protected virtual List<string> ValidarRegistroDuplicado(T novaEntidade, string? idSelecionado = null)
    {
        return new List<string>();
    }

    public void Cadastrar()
    {
        ExibirCabecalho($"Cadastro de {nomeEntidade}");

        T novaEntidade = ObterDadosCadastrais();

        List<string> erros = novaEntidade.Validar();

        if (erros.Count > 0)
        {
            Console.WriteLine("---------------------------------");

            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Count; i++)
            {
                string erro = erros[i];

                Console.WriteLine(erro);
            }

            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();

            Cadastrar();
            return;
        }

        List<string> errosValidacao = ValidarRegistroDuplicado(novaEntidade);

        if (errosValidacao.Count > 0)
        {
            Notificador.ExibirMensagensErro(errosValidacao);

            Cadastrar();
            return;
        }

        repositorio.Cadastrar(novaEntidade);

        Notificador.ExibirMensagem($"O registro \"{novaEntidade.Id}\" foi cadastrado com sucesso!");
    }

    public void Editar()
    {
        ExibirCabecalho($"Edição de {nomeEntidade}");

        VisualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o ID do registro que deseja editar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Console.WriteLine("---------------------------------");

        T novaEntidade = ObterDadosCadastrais();

        List<string> erros = novaEntidade.Validar();

        if (erros.Count > 0)
        {
            Console.WriteLine("---------------------------------");

            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Count; i++)
            {
                string erro = erros[i];

                Console.WriteLine(erro);
            }

            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();

            Editar();
            return;
        }


        List<string> errosValidacao = ValidarRegistroDuplicado(novaEntidade, idSelecionado);

        if (errosValidacao.Count > 0)
        {
            Notificador.ExibirMensagensErro(errosValidacao);

            Cadastrar();
            return;
        }


        bool conseguiuEditar = repositorio.Editar(idSelecionado, novaEntidade);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Não foi possível encontrar o registro requisitado.");
            return;
        }

        Notificador.ExibirMensagem($"O registro \"{idSelecionado}\" foi editado com sucesso.");
    }

    public void Excluir()
    {
        ExibirCabecalho("Exclusão de Caixa");

        VisualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o ID do registro que deseja excluir (ou S para sair): ");
            idSelecionado = Console.ReadLine() ?? string.Empty;

            if (idSelecionado.ToUpper() == "S")
                return;

            if (idSelecionado.Length == 7)
                break;
        } while (true);

        T? registroSelecionado = repositorio.SelecionarPorId(idSelecionado);

        if (registroSelecionado == null)
        {
            Notificador.ExibirMensagem("Não foi possível encontrar o registro requisitado.");

            Excluir();
            return;
        }

        List<string> errosDuplicacao = ValidarExclusaoRegistro(registroSelecionado);

        if (errosDuplicacao.Count > 0)
        {
            Notificador.ExibirMensagensErro(errosDuplicacao);
            return;
        }

        repositorio.Excluir(registroSelecionado);

        Notificador.ExibirMensagem($"O registro \"{idSelecionado}\" foi excluído com sucesso.");
    }

    public abstract void VisualizarTodos(bool deveExibirCabecalho);

    protected void ExibirCabecalho(string titulo)
    {
        // Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestão de {nomeEntidade}");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(titulo);
        Console.WriteLine("---------------------------------");
    }

    protected virtual List<string> ValidarExclusaoRegistro(T registro)
    {
        return new List<string>();
    }
    protected abstract T ObterDadosCadastrais();
}