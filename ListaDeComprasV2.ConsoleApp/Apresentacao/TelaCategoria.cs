using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.Repositorio;

namespace ListaDeComprasV2.ConsoleApp.Apresentacao;

public class TelaCategoria : TelaBase, ITela
{
    private RepositorioCategoria repositorioCategoria;

    public TelaCategoria(RepositorioCategoria repositorioCategoria)
        : base(nomeEntidade: "Categoria", repositorio: repositorioCategoria)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        throw new NotImplementedException();
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        throw new NotImplementedException();
    }
}