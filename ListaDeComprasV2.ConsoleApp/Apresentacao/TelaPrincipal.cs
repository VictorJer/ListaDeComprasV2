using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.Repositorio;

namespace ListaDeComprasV2.ConsoleApp.Apresentacao;

public class TelaPrincipal
{
    private RepositorioCategoria repositorioCategoria = new RepositorioCategoria();

    public ITelaOpcoes? ApresentarMenuOpcoesPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Lista de Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar categorias");
        Console.WriteLine("2 - Gerenciar produtos");
        Console.WriteLine("3 - Gerenciar listas de compras");
        Console.WriteLine("4 - Gerenciar itens de listas de compras");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaCategoria(repositorioCategoria);

        return null;
    }
}