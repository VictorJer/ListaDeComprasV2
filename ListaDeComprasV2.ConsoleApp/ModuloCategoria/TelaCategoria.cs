using System.Collections;
using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.Dominio;
using ListaDeComprasV2.ConsoleApp.Repositorio;

namespace ListaDeComprasV2.ConsoleApp.Apresentacao;

public class TelaCategoria : TelaBase<Categoria>, ITelaOpcoes, ITelaCrud
{

    public TelaCategoria(RepositorioCategoria repositorio) : base(nomeEntidade: "Categoria", repositorio: repositorio)
    {

    }


    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de categoria");


        List<Categoria> categorias = repositorio.SelecionarTodos();

        if (categorias.Count == 0)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Nem uma Categoria encontrada");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("ENTER para continuar...");

            return;
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Nome", "Cor"
        );

        foreach (Categoria c in categorias)
        {

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10}",
                c.Id, c.Nome, c.Cor
            );
        }
    }

    protected override Categoria ObterDadosCadastrais()
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

    protected override List<string> ValidarRegistroDuplicado(Categoria novaEntidade, string? idIgnorado = null)
    {
        List<string> erros = new List<string>();

        List<Categoria> categorias = repositorio.SelecionarTodos();

        foreach (Categoria c in categorias)
        {
            if (c.Id != idIgnorado && c.Nome == novaEntidade.Nome)
            {
                erros.Add("Ja existe uma categoria com esse nome");
                break;
            }
        }

        return erros;
    }
}