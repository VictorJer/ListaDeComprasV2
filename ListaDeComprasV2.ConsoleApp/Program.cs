using ListaDeComprasV2.ConsoleApp.Apresentacao;
using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.Repositorio;

RepositorioCategoria repositorioCategoria = new RepositorioCategoria();

TelaPrincipal telaPrincipal = new TelaPrincipal(repositorioCategoria);

while (true)
{
    ITela? telaSelecionada = telaPrincipal.ApresentarMenuOpcoesPrincipal();

    if (telaSelecionada == null)
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoSubMenu = telaSelecionada.ObterOpcaoMenu();

        if (telaSelecionada is TelaBase telaBase) // <= esse mano aqui ja muda a telaSelecionada para TelaBase
        {
            if (opcaoSubMenu == "1")
                telaBase.Cadastrar();

            else if (opcaoSubMenu == "2")
                telaBase.Editar();

            else if (opcaoSubMenu == "3")
                telaBase.Excluir();

            else if (opcaoSubMenu == "4")
                telaBase.VisualizarTodos(deveExibirCabecalho: true);
        }
    }
}