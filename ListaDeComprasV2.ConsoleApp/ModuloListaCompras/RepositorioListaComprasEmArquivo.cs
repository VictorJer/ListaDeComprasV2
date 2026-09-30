using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.Compartilhado.Arquivos;

namespace ListaDeComprasV2.ConsoleApp.ModuloListaCompras;

public class RepositorioListaComprasEmArquivo : RepositorioBaseEmArquivo<ListaCompras>, IRepositorio<ListaCompras>
{
    public RepositorioListaComprasEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<ListaCompras> CarregarRegistros()
    {
        return contexto.ListaCompras;
    }
}