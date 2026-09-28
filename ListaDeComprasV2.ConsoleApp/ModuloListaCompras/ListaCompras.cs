using ListaDeComprasV2.ConsoleApp.Compartilhado;

namespace ListaDeComprasV2.ConsoleApp.ModuloListaCompras;

public class ListaCompras : EntidadeBase
{
    public string Nome { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public StatusListaCompras Status { get; private set; }

    public ListaCompras(string nome)
    {
        Nome = nome;
        DataCriacao = DateTime.Now;

        Abrir();
    }

    public void Abrir()
    {
        Status = StatusListaCompras.Aberto;
    }

    public void Concluir()
    {
        Status = StatusListaCompras.Concluido;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}