using Vikingos.Core.Interfaces;

namespace Vikingos.Core.Entidades.Abstract;

public abstract class Rol : IRol
{
    public abstract bool EsProductivo(Vikingo vikingo);
}
