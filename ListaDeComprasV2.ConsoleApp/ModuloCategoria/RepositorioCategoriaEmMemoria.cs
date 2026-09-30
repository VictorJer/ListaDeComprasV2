using ListaDeComprasV2.ConsoleApp.Compartilhado;
using ListaDeComprasV2.ConsoleApp.Compartilhado.Memoria;
using ListaDeComprasV2.ConsoleApp.Dominio;

namespace ListaDeComprasV2.ConsoleApp.Repositorio;

public class RepositorioCategoriaEmMemoria : RepositorioBaseEmMemoria<Categoria>, IRepositorio<Categoria>;