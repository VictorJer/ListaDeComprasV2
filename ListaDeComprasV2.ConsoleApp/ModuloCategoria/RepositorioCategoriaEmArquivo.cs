using ListaDeComprasV2.ConsoleApp.Compartilhado.Arquivos;
using ListaDeComprasV2.ConsoleApp.Dominio;

namespace ListaDeComprasV2.ConsoleApp.ModuloCategoria;

public class RepositorioCategoriaEmArquivo : RepositorioBaseEmArquivo<Categoria>
{
    public RepositorioCategoriaEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Categoria> CarregarRegistros()
    {
        return contexto.Categorias;
    }
}