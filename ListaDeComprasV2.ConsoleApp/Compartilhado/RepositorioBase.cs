using System.Collections;
namespace ListaDeComprasV2.ConsoleApp.Compartilhado;

public abstract class RepositorioBase
{
    // protected EntidadeBase?[] registros = new EntidadeBase[100];

    protected List<EntidadeBase> registros = new List<EntidadeBase>();

    public void Cadastrar(EntidadeBase entidade)
    {
        registros.Add(entidade);
    }

    public bool Editar(string idSelecionado, EntidadeBase entidade)
    {
        EntidadeBase? entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        entidadeSelecionada.AtualizarDados(entidade);

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        EntidadeBase? entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        registros.Remove(entidadeSelecionada);

        return true;
    }

    public EntidadeBase? SelecionarPorId(string idSelecionado)
    {
        foreach (EntidadeBase registro in registros)
        {
            if (registro.Id == idSelecionado)
                return registro;
        }

        return null;

    }

    public List<EntidadeBase> SelecionarTodos()
    {
        return registros;
    }
}