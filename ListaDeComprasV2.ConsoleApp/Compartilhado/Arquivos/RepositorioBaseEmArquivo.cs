namespace ListaDeComprasV2.ConsoleApp.Compartilhado.Arquivos;

public abstract class RepositorioBaseEmArquivo<T> where T : EntidadeBase
{
    protected ContextoJson contexto;
    protected List<T> registros;

    public RepositorioBaseEmArquivo(ContextoJson contexto)
    {
        this.contexto = contexto;
        this.registros = CarregarRegistros();
    }
    protected abstract List<T> CarregarRegistros();

    public void Cadastrar(T entidade)
    {
        registros.Add(entidade);

        contexto.Salvar();
    }

    public bool Editar(string idSelecionado, T entidade)
    {
        T? entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        entidadeSelecionada.AtualizarDados(entidade);

        contexto.Salvar();

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