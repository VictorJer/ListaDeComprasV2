using ListaDeComprasV2.ConsoleApp.Compartilhado;

namespace ListaDeComprasV2.ConsoleApp.ModuloListaCompras;

public class ListaCompras : EntidadeBase
{
    public string Nome { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public StatusListaCompras Status { get; private set; }
    public List<ItemListaCompras> Itens { get; private set; } = new List<ItemListaCompras>();


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

    public void AdicionarItem(Produto produto, int quantidade)
    {
        ItemListaCompras itemADD = new ItemListaCompras(produto, quantidade);

        Itens.Add(itemADD);
    }

    public bool RemoverItem(string IdItem)
    {
        foreach (ItemListaCompras item in Itens)
        {
            if (item.Id == IdItem)
                Itens.Remove(item);
            return true;
        }

        return false;
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