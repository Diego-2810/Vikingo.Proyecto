using Vikingos.Core.Entidades.Abstract;

namespace Vikingos.Core.Entidades;

public class Karl : CastaSocial
{
    public override void Ascender(Vikingo vikingo)
    {
        vikingo.Casta = new Thrall();
    }
}
