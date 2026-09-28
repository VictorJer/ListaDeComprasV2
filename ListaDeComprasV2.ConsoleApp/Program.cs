using System.Text.Json;
using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.Dominio;
using ListaDeComprasV2.ConsoleApp.ModuloListaCompras;
using ListaDeComprasV2.ConsoleApp.Utilidade;

//===================================================================

// string caminhoDowloads = "C:\\Users\\victo\\Downloads";
// string caminhoArquivo = caminhoDowloads + "\\categoria.json";

// Categoria categoria = new Categoria("cafe", "Vermelho");

// string jsonString = JsonSerializer.Serialize(categoria);

// File.WriteAllText(caminhoArquivo, jsonString);

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