using System.Collections;
using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.Dominio;
using ListaDeComprasV2.ConsoleApp.Repositorio;

namespace ListaDeComprasV2.ConsoleApp.Apresentacao;

public class TelaCategoria : TelaBase
{
    private RepositorioCategoria repositorioCategoria;

    public TelaCategoria(RepositorioCategoria repositorioCategoria)
        : base(nomeEntidade: "Categoria", repositorio: repositorioCategoria)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de categoria");


        List<EntidadeBase> categoria = repositorioCategoria.SelecionarTodos();

        if (categoria.Count == 0)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Nem uma Categoria encontrada");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("ENTER para continuar...");

            return;
        }

        Console.WriteLine(
            "{0,-12} | {1, -7}"
            , "Nome", "Cor");


        foreach (Categoria c in categoria)
        {

            Console.WriteLine(
        "{0,-12} | {1, -7}"
        , c.Nome, c.Cor);
        }
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Digite o nome da categoria: ");
        string nome = Console.ReadLine() ?? "";

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Selecione uma cor válida para a categoria");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Vermelho");
        Console.WriteLine("2 - Azul");
        Console.WriteLine("3 - Verde");
        Console.WriteLine("4 - Branco (Padrão)");
        Console.WriteLine("---------------------------------");
        Console.Write("Digite a cor da categoria: ");
        string cor = Console.ReadLine() ?? "";

        string corPorExtenso = string.Empty;

        if (cor == "1")
            corPorExtenso = "Vermelho";
        else if (cor == "2")
            corPorExtenso = "Azul";
        else if (cor == "3")
            corPorExtenso = "Verde";
        else
            corPorExtenso = "Branco";

        return new Categoria(nome, corPorExtenso);
    }
}