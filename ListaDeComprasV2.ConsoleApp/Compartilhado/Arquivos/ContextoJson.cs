using System.Text.Json;
using System.Text.Json.Serialization;
using ListaDeComprasV2.ConsoleApp.Dominio;
using ListaDeComprasV2.ConsoleApp.ModuloListaCompras;

namespace ListaDeComprasV2.ConsoleApp.Compartilhado.Arquivos;

public class ContextoJson
{
    public List<Categoria> Categorias { get; set; } = new List<Categoria>();
    public List<Produto> Produtos { get; set; } = new List<Produto>();
    public List<ListaCompras> ListaCompras { get; set; } = new List<ListaCompras>();

    public void Salvar()
    {
        string caminhoDiretorio = "C:\\Users\\victo\\Downloads";

        string caminhoArquivo = caminhoDiretorio + "\\dados.json";

        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.WriteIndented = true;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve; // preserva as referencias

        string jsonString = JsonSerializer.Serialize(this, opcoesJson);

        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void Carregar()
    {
        string caminhoDiretorio = "C:\\Users\\victor\\Downloads";

        string caminhoArquivo = caminhoDiretorio + "\\dados.json";

        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve; // preserva as referencias

        string jsonString = File.ReadAllText(caminhoArquivo);

        ContextoJson? contextoSalvo = JsonSerializer.Deserialize<ContextoJson>(jsonString, opcoesJson);

        if (contextoSalvo == null)
            return;

        this.Categorias = contextoSalvo.Categorias;
        this.Produtos = contextoSalvo.Produtos;
        this.ListaCompras = contextoSalvo.ListaCompras;
    }
}
