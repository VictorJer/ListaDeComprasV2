using ListaDeComprasV2.ConsoleApp.Compartilhado;

namespace ListaDeComprasV2.ConsoleApp.ModuloListaCompras;

public class ListaCompras : EntidadeBase<ListaCompras>
{
    public string Nome { get; set; } = string.Empty;
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
        ArgumentNullException.ThrowIfNull(produto);

        if (quantidade <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantidade), "A quantidade deve ser maior que zero.");

        ItemListaCompras itemADD = new ItemListaCompras(produto, quantidade);

        Itens.Add(itemADD);
    }

    public bool RemoverItem(string IdItem)
    {
        ItemListaCompras? item = Itens.FirstOrDefault(item => item.Id == IdItem);
        return item != null && Itens.Remove(item);
    }

    public override void AtualizarDados(ListaCompras entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
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