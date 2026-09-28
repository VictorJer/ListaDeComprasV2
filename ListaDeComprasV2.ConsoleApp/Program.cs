using System.Text.Json;
using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.Compartilhado.Arquivos;
using ListaDeComprasV2.ConsoleApp.Dominio;
using ListaDeComprasV2.ConsoleApp.ModuloListaCompras;
using ListaDeComprasV2.ConsoleApp.Utilidade;

//===================================================================
// ContextoJson contexto = new ContextoJson();

// // contexto.Categorias.Add(categoria);
// // contexto.Produtos.Add(new Produto("cafezes", "200g", 27, categoria));
// // contexto.Salvar();

// contexto.Carregar();

// return;
//===================================================================

TelaPrincipal telaPrincipal = new TelaPrincipal();



while (true)
{
    ITelaOpcoes? telaSelecionada = telaPrincipal.ApresentarMenuOpcoesPrincipal();

    if (telaSelecionada == null)
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoSubMenu = telaSelecionada.ObterOpcaoMenu();

        if (telaSelecionada is ITelaCrud telaBase) // <= esse mano aqui ja muda a telaSelecionada para TelaBase
        {
            if (opcaoSubMenu == "1")
                telaBase.Cadastrar();

            else if (opcaoSubMenu == "2")
                telaBase.Editar();

            else if (opcaoSubMenu == "3")
                telaBase.Excluir();

            else if (opcaoSubMenu == "4")
                telaBase.VisualizarTodos(deveExibirCabecalho: true);

            if (telaBase is TelaListaCompras telaListaCompras)
            {
                if (opcaoSubMenu == "5")
                    telaListaCompras.AdicionarItem();

                else if (opcaoSubMenu == "6")
                    telaListaCompras.RemoverItem();

                else if (opcaoSubMenu == "7")
                    telaListaCompras.VisualizarItens();
            }
        }
    }
}