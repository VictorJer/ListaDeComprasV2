using ListaDeComprasV2.ConsoleApp.Dominio;
using ListaDeComprasV2.ConsoleApp.ModuloListaCompras;

namespace ListaDeCompras.TestProject.TestesUnitarios.ListasCompras;

[TestClass]
public sealed class ListaComprasTest
{
    [TestMethod]
    public void NovaListaDeveSerCriadaAberta()
    {
        ListaCompras lista = new ListaCompras("Compras da semana");

        Assert.AreEqual(StatusListaCompras.Aberto, lista.Status);
        Assert.AreEqual("Compras da semana", lista.Nome);
        Assert.HasCount(0, lista.Itens);
    }

    [TestMethod]
    public void ConcluirEReabrirListaDeveAtualizarStatus()
    {
        ListaCompras lista = new ListaCompras("Compras da semana");

        lista.Concluir();
        Assert.AreEqual(StatusListaCompras.Concluido, lista.Status);

        lista.Abrir();
        Assert.AreEqual(StatusListaCompras.Aberto, lista.Status);
    }

    [TestMethod]
    public void AdicionarItemDeveAtualizarQuantidadeETotal()
    {
        ListaCompras lista = new ListaCompras("Compras da semana");
        Produto produto = CriarProduto(7.50m);

        lista.AdicionarItem(produto, 3);

        Assert.HasCount(1, lista.Itens);
        Assert.AreEqual(3, lista.Itens[0].Quantidade);
        Assert.AreEqual(22.50m, lista.Itens[0].Preco);
        Assert.AreEqual(22.50m, lista.TotalGasto);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void AdicionarItemComQuantidadeInvalidaDeveLancarExcecao(int quantidade)
    {
        ListaCompras lista = new ListaCompras("Compras da semana");

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(
            () => lista.AdicionarItem(CriarProduto(7.50m), quantidade));
    }

    [TestMethod]
    public void RemoverItemExistenteDeveRetornarVerdadeiroERemoverItem()
    {
        ListaCompras lista = new ListaCompras("Compras da semana");
        lista.AdicionarItem(CriarProduto(7.50m), 3);
        string idItem = lista.Itens[0].Id;

        bool removido = lista.RemoverItem(idItem);

        Assert.IsTrue(removido);
        Assert.HasCount(0, lista.Itens);
    }

    [TestMethod]
    public void RemoverItemInexistenteDeveRetornarFalso()
    {
        ListaCompras lista = new ListaCompras("Compras da semana");
        lista.AdicionarItem(CriarProduto(7.50m), 3);

        bool removido = lista.RemoverItem("inexistente");

        Assert.IsFalse(removido);
        Assert.HasCount(1, lista.Itens);
    }

    [TestMethod]
    public void ListaComNomeValidoDeveRetornarSemErros()
    {
        ListaCompras lista = new ListaCompras("Compras da semana");

        var erros = lista.Validar();

        Assert.HasCount(0, erros);
    }

    [TestMethod]
    public void ListaSemNomeDeveRetornarErro()
    {
        ListaCompras lista = new ListaCompras(" ");

        var erros = lista.Validar();

        CollectionAssert.Contains(erros, "O campo \"Nome\" deve ser preenchido!");
    }

    [TestMethod]
    public void AtualizarDadosDeveAlterarNomeEPreservarDadosDaLista()
    {
        ListaCompras lista = new ListaCompras("Compras da semana");
        lista.AdicionarItem(CriarProduto(7.50m), 2);
        string idOriginal = lista.Id;
        DateTime dataCriacaoOriginal = lista.DataCriacao;
        ListaCompras dadosAtualizados = new ListaCompras("Compras do mes");

        lista.AtualizarDados(dadosAtualizados);

        Assert.AreEqual("Compras do mes", lista.Nome);
        Assert.AreEqual(idOriginal, lista.Id);
        Assert.AreEqual(dataCriacaoOriginal, lista.DataCriacao);
        Assert.HasCount(1, lista.Itens);
    }

    private static Produto CriarProduto(decimal preco)
    {
        return new Produto("Arroz", "Kg", preco, new Categoria("Alimentos", "Vermelho"));
    }
}