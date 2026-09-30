using ListaDeComprasV2.ConsoleApp.Dominio;

namespace ListaDeCompras.TestProject.TestesUnitarios.Produtos;

[TestClass]
public sealed class ProdutoTest
{
    [TestMethod]
    public void NovoProdutoValidoDeveRetornarSemErros()
    {
        Produto produto = CriarProduto();

        var erros = produto.Validar();

        Assert.HasCount(0, erros);
    }

    [TestMethod]
    public void ProdutoComNomeForaDoLimiteDeveRetornarErro()
    {
        Produto produto = new Produto("A", "Unidade", 10m, CriarCategoria());

        var erros = produto.Validar();

        CollectionAssert.Contains(erros, "O campo \"Nome\" deve conter entre 2 e 100 caracteres.");
    }

    [TestMethod]
    public void ProdutoSemUnidadeDeMedidaDeveRetornarErro()
    {
        Produto produto = new Produto("Arroz", "", 10m, CriarCategoria());

        var erros = produto.Validar();

        CollectionAssert.Contains(erros, "O campo \"Unidade de Medida\" deve ser preenchido.");
    }

    [TestMethod]
    public void ProdutoSemPrecoDeveRetornarErro()
    {
        Produto produto = new Produto("Arroz", "Kg", 0m, CriarCategoria());

        var erros = produto.Validar();

        CollectionAssert.Contains(erros, "O campo \"Preço Aproximado\" deve ser maior que zero.");
    }

    [TestMethod]
    public void ProdutoComPrecoNegativoDeveRetornarErro()
    {
        Produto produto = new Produto("Arroz", "Kg", -1m, CriarCategoria());

        var erros = produto.Validar();

        CollectionAssert.Contains(erros, "O campo \"Preço Aproximado\" deve ser maior que zero.");
    }

    private static Categoria CriarCategoria()
    {
        return new Categoria("Alimentos", "Vermelho");
    }

    private static Produto CriarProduto()
    {
        return new Produto("Arroz", "Kg", 10m, CriarCategoria());
    }
}