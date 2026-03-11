using Vikingos.Core.Entidades.Abstract;

namespace Vikingos.Core.Entidades;

public class Soldado : Rol
{
    public override bool EsProductivo(Vikingo vikingo)
    {
        return vikingo.VidasCobradas > 20 && vikingo.Armas > 0;
    }
}
