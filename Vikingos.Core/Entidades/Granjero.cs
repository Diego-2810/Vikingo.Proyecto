using Vikingos.Core.Entidades.Abstract;

namespace Vikingos.Core.Entidades;

public class Granjero : Rol
{
    public override bool EsProductivo(Vikingo vikingo)
    {
        if (vikingo.Hijos == 0) return true;
        return vikingo.Hectareas >= vikingo.Hijos * 2;
    }
}
