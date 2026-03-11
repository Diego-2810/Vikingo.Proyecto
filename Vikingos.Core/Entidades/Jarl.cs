using Vikingos.Core.Entidades.Abstract;

namespace Vikingos.Core.Entidades;

public class Jarl : CastaSocial
{
    public override void Ascender(Vikingo vikingo)
    {
        vikingo.Casta = new Karl();
        
        if (vikingo.Rol is Soldado)
            vikingo.Armas += 10;
        else
        {
            vikingo.Hijos += 2;
            vikingo.Hectareas += 2;
        }
    }
}
