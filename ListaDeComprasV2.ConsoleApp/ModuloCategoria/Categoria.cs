using ListaDeComprasV2.ConsoleApp.Compartilhado;
namespace ListaDeComprasV2.ConsoleApp.Dominio;

public class Categoria : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;

    public Categoria() { }
    public Categoria(string nome, string cor)
    {
        Nome = nome;
        Cor = cor;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Categoria categoriaAtualizada = (Categoria)entidadeAtualizada;

        Nome = categoriaAtualizada.Nome;
        Cor = categoriaAtualizada.Cor;
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

        string[] coresValidas = { "Vermelho", "Azul", "Verde", "Branco" };

        if (!coresValidas.Contains(Cor, StringComparer.OrdinalIgnoreCase))
            erros.Add("O campo \"Cor\" deve conter uma opção valida");

        return erros;
    }
}