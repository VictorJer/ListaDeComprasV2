using System.Security.Cryptography;

namespace ListaDeComprasV2.ConsoleApp.ModuloListaCompras;

public class ItemListaCompras
{
    public string Id { get; set; } = string.Empty;
    public Produto Produto { get; set; } = null!;
    public int Quantidade { get; set; }
    public decimal Preco
    {
        get
        {
            return Produto.PrecoAproximado * Quantidade;
        }
    }

    public ItemListaCompras() { }
    public ItemListaCompras(Produto produto, int quantidade)
    {
        Id = Convert
                .ToHexString(RandomNumberGenerator.GetBytes(4))
                .ToLower()
                .Substring(0, 7);


        Produto = produto;
        Quantidade = quantidade;
    }
}