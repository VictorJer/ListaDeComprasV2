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
}
