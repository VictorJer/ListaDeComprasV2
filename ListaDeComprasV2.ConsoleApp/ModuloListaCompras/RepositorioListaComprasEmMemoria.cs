using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.Compartilhado.Memoria;

namespace ListaDeComprasV2.ConsoleApp.ModuloListaCompras;

public class RepositorioListaComprasEmMemoria : RepositorioBaseEmMemoria<ListaCompras>, IRepositorio<ListaCompras>;