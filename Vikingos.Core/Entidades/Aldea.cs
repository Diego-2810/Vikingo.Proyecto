using Vikingos.Core.Entidades.Abstract;

namespace Vikingos.Core.Entidades;

public class Aldea : Lugar
{
    public int Crucifijos { get; set; }

    public Aldea(string nombre, int crucifijos) 
        : base(nombre, defensores: 0)
    {
        Crucifijos = crucifijos;
    }

    public override bool ValelaPena(int cantidadVikingos)
    {
        return Crucifijos >= 15;
    }

    public override double CalcularBotin()
    {
        return Crucifijos;
    }

    public override void Invadir()
    {
        Crucifijos = 0;
        base.Invadir();
    }
}
