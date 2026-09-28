using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.Dominio;
namespace ListaDeCompras.TestProject.TestesUnitarios.Categorias;

[TestClass]
public sealed class CategoriaTest
{
    [TestMethod]
    public void NovaCategoriaDeveRetornarSemErros()
    {
        Categoria categoria = new Categoria("Vitu", "1");

        var erros = categoria.Validar();

        Assert.HasCount(0, erros);
    }

    [TestMethod]
    public void CategoriaComNomeVazioDeveRetornarErro()
    {
        Categoria categoria = new Categoria("", "1");

        var erros = categoria.Validar();

        CollectionAssert.Contains(erros, "O campo \"Nome\" deve ser preenchido!");
    }

    [TestMethod]
    public void CategoriaComNomeCurtoDeveRetornarErro()
    {
        Categoria categoria = new Categoria("A", "1");

        var erros = categoria.Validar();

        CollectionAssert.Contains(erros, "O campo \"Nome\" deve conter no minimo 2 caracteres");
    }

    [TestMethod]
    public void CategoriaComCorInvalidaDeveRetornarErro()
    {
        Categoria categoria = new Categoria("Bebidas", "4");

        var erros = categoria.Validar();

        CollectionAssert.Contains(erros, "O campo \"Cor\" deve conter uma opção valida");
    }
}
