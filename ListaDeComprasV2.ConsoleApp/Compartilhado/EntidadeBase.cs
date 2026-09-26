using System.Security.Cryptography;

namespace ListaDeComprasV2.ConsoleApp.Compartilhado;

public abstract class EntidadeBase
{
    public string Id { get; private set; } = string.Empty;

    public EntidadeBase()
    {
        Id = Convert
                .ToHexString(RandomNumberGenerator.GetBytes(4))
                .ToLower()
                .Substring(0, 7);
    }

    public abstract List<string> Validar();
    public abstract void AtualizarRegistro(EntidadeBase entidadeAtualizada);
}