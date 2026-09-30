using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.Compartilhado.Arquivos;

namespace ListaDeComprasV2.ConsoleApp.ModuloProduto;

public class RepositorioProdutoEmArquivo : RepositorioBaseEmArquivo<Produto>, IRepositorio<Produto>
{
    public RepositorioProdutoEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Produto> CarregarRegistros()
    {
        return contexto.Produtos;
    }
}