using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.Dominio;
using ListaDeComprasV2.ConsoleApp.ModuloCategoria;
using ListaDeComprasV2.ConsoleApp.ModuloProduto;
using ListaDeComprasV2.ConsoleApp.Repositorio;
using ListaDeComprasV2.ConsoleApp.Utilidade;

public class TelaProduto : TelaBase<Produto>, ITelaOpcoes, ITelaCrud
{
    private readonly IRepositorio<Categoria> repositorioCategoria;
    public TelaProduto(IRepositorio<Produto> repositorioProduto, IRepositorio<Categoria> repositorioCategoria) : base("Produto", repositorioProduto)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de produtos");

        List<Produto> produtos = repositorio.SelecionarTodos();

        if (produtos.Count == 0)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Nenhum produto encontrado.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("ENTER para continuar...");

            return;
        }

        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -15} | {3, -20} | {4, -15}",
            "Id", "Nome", "Medida", "Preço Aproximado", "Categoria");


        foreach (Produto p in produtos)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -20} | {4, -15}",
                p.Id, p.Nome, p.UnidadeMedida, p.PrecoAproximado.ToString("C2"), p.Categoria.Nome
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }

    }

    protected override Produto? ObterDadosCadastrais()
    {
        if (repositorioCategoria.SelecionarTodos().Count == 0)
        {
            Notificador.ExibirMensagem("Cadastre uma categoria antes de cadastrar um produto.");
            return null;
        }

        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite a unidade de medida do produto (ex: 2 lt, 5 kg): ");
        string unidadeMedida = Console.ReadLine() ?? string.Empty;

        decimal precoAproximado;
        while (true)
        {
            Console.Write("Digite o preço aproximado do produto em R$: ");
            if (decimal.TryParse(Console.ReadLine(), out precoAproximado) && precoAproximado > 0)
                break;

            Console.WriteLine("Digite um preço válido maior que zero.");
        }

        Categoria? categoriaSelecionada;

        do
        {
            Console.WriteLine("---------------------------------");
            VisualizarCategorias();
            Console.WriteLine("---------------------------------");

            Console.Write("Digite o Id da categoria do produto (ou S para cancelar): ");
            string idSelecionado = Console.ReadLine()?.Trim() ?? string.Empty;

            if (idSelecionado.Equals("S", StringComparison.OrdinalIgnoreCase))
                return null;

            categoriaSelecionada = repositorioCategoria.SelecionarPorId(idSelecionado);

        } while (categoriaSelecionada == null);

        return new Produto(nome, unidadeMedida, precoAproximado, categoriaSelecionada);
    }

    private void VisualizarCategorias()
    {
        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        if (categorias.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Não existe nenhum registro.");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Nome", "Cor"
        );

        foreach (Categoria c in categorias)
        {

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10}",
                c.Id, c.Nome, c.Cor
            );
        }

    }
}