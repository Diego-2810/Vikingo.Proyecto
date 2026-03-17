using Vikingos.Core.Entidades.Abstract;

namespace Vikingos.Core.Entidades;

public class Capital : Lugar
{
    public double FactorRiqueza { get; set; }

    public Capital(string nombre, int defensores, double factorRiqueza) 
        : base(nombre, defensores)
    {
        FactorRiqueza = factorRiqueza;
    }

    public override bool ValelaPena(int cantidadVikingos)
    {
        if (cantidadVikingos == 0) return false;
        
        double botin = CalcularBotin();
        double monidasPorVikingo = botin / cantidadVikingos;
        
        return monidasPorVikingo >= 3;
    }

    public override double CalcularBotin()
    {
        return Defensores * FactorRiqueza;
    }
}
