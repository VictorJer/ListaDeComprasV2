using ListaDeComprasV2.ConsoleApp.Apresentacao;
using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.ModuloCategoria;
using ListaDeComprasV2.ConsoleApp.ModuloListaCompras;
using ListaDeComprasV2.ConsoleApp.ModuloProduto;
using ListaDeComprasV2.ConsoleApp.Repositorio;

namespace ListaDeComprasV2.ConsoleApp.Utilidade;

public class TelaPrincipal
{
    private readonly RepositorioCategoriaEmArquivo repositorioCategoria;
    private readonly RepositorioProdutoEmArquivo repositorioProduto;
    private readonly RepositorioListaComprasEmArquivo repositorioListaCompras;

    public TelaPrincipal(RepositorioCategoriaEmArquivo repositorioCategoria, RepositorioProdutoEmArquivo repositorioProduto, RepositorioListaComprasEmArquivo repositorioListaCompras)
    {
        this.repositorioCategoria = repositorioCategoria;
        this.repositorioProduto = repositorioProduto;
        this.repositorioListaCompras = repositorioListaCompras;
    }

    public ITelaOpcoes? ApresentarMenuOpcoesPrincipal()
    {
        // Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Lista de Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar categorias");
        Console.WriteLine("2 - Gerenciar produtos");
        Console.WriteLine("3 - Gerenciar listas de compras");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "S")
            return null;

        if (opcaoMenuPrincipal == "1")
            return new TelaCategoria(repositorioCategoria);

        if (opcaoMenuPrincipal == "2")
            return new TelaProduto(repositorioProduto, repositorioCategoria);

        if (opcaoMenuPrincipal == "3")
            return new TelaListaCompras(repositorioListaCompras, repositorioProduto);

        return null;
    }
}