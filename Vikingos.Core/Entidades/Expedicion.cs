using Vikingos.Core.Entidades.Abstract;

namespace Vikingos.Core.Entidades;

public class Expedicion
{
    public string Nombre { get; set; }
    public List<Vikingo> Vikingos { get; set; }
    public List<Lugar> Lugares { get; set; }

    public Expedicion(string nombre)
    {
        Nombre = nombre;
        Vikingos = new List<Vikingo>();
        Lugares = new List<Lugar>();
    }

    public bool SubirVikingo(Vikingo vikingo)
    {
        if (!vikingo.PuedeIrAExpedicion())
            return false;

        Vikingos.Add(vikingo);
        return true;
    }

    public int CantidadVikingo()
    {
        return Vikingos.Count;
    }

    public void AgregarLugar(Lugar lugar)
    {
        Lugares.Add(lugar);
    }

    public bool RealizarExpedicion()
    {
        return ValelaPena();
    }

    private bool ValelaPena()
    {
        int cantidadVikingos = CantidadVikingo();
        
        if (Lugares.Count == 0)
            return false;

        return Lugares.All(lugar => lugar.ValelaPena(cantidadVikingos));
    }

    public string ObtenerResumen()
    {
        return $"Expedición: {Nombre}\n" +
               $"Vikingos: {CantidadVikingo()}\n" +
               $"Lugares: {Lugares.Count}\n" +
               $"Vale la pena: {RealizarExpedicion()}";
    }
}
