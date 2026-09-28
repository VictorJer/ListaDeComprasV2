using ListaDeComprasV2.ConsoleApp.Compartilhado;

namespace ListaDeComprasV2.ConsoleApp.ModuloListaCompras;

public class ListaCompras : EntidadeBase
{
    public string Nome { get; set; }
    public DateTime DataCriacao { get; set; }
    public StatusListaCompras Status { get; set; }
    public List<ItemListaCompras> Itens { get; set; } = new List<ItemListaCompras>();
    public decimal TotalGasto
    {
        get
        {
            decimal totalGasto = 0;

            foreach (ItemListaCompras item in Itens)
                totalGasto += item.Preco;

            return totalGasto;
        }
    }

    public ListaCompras() { }
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
            {
                Itens.Remove(item);
                return true;
            }
        }

        return false;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        ListaCompras listaAtualizada = (ListaCompras)entidadeAtualizada;

        Nome = listaAtualizada.Nome;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" deve ser preenchido!");
        else if (Nome.Length < 2)
            erros.Add("O campo \"Nome\" deve conter no minimo 2 caracteres");
        else if (Nome.Length > 50)
            erros.Add("O campo \"Nome\" deve conter no maximo 50 caracteres");

        return erros;
    }
}