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

    private readonly string caminhoArquivo;

    public ContextoJson()
    {
        string caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        string caminhoDiretorio = Path.Combine(caminhoAppData, "ListaCCompras");

        Directory.CreateDirectory(caminhoDiretorio);

        caminhoArquivo = Path.Combine(caminhoDiretorio, "dados.json");
    }

    public void Salvar()
    {
        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.WriteIndented = true;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve; // preserva as referencias

        string jsonString = JsonSerializer.Serialize(this, opcoesJson);

        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void Carregar()
    {
        if (!File.Exists(caminhoArquivo))
            return;

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
