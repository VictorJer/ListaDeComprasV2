using System.Collections;
namespace ListaDeComprasV2.ConsoleApp.Compartilhado.Memoria;

public abstract class RepositorioBaseEmMemoria<T> where T : EntidadeBase<T>
{
    protected List<T> registros = new List<T>();

    public void Cadastrar(T entidade)
    {
        registros.Add(entidade);
    }

    public bool Editar(string idSelecionado, T entidade)
    {
        T? entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        entidadeSelecionada.AtualizarDados(entidade);

        return true;
    }

    public bool Excluir(T registro)
    {
        return registros.Remove(registro);
    }

    public bool Excluir(string idSelecionado)
    {
        T? registroSelecionado = SelecionarPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;

        registros.Remove(registroSelecionado);

        return true;
    }

    public T? SelecionarPorId(string idSelecionado)
    {
        foreach (T registro in registros)
        {
            if (registro.Id == idSelecionado)
                return registro;
        }

        return null;

    }

    public List<T> SelecionarTodos()
    {
        return registros;
    }
}