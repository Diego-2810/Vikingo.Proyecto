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

    public (bool Exito, string Mensaje) IntentarSubirVikingo(Vikingo vikingo)
    {
        if (!vikingo.PuedeIrAExpedicion())
            return (false, $"{vikingo.Nombre} no puede subir a la expedición");

        Vikingos.Add(vikingo);
        return (true, $"{vikingo.Nombre} subió correctamente a la expedición");
    }

    public bool SubirVikingo(Vikingo vikingo)
    {
        return IntentarSubirVikingo(vikingo).Exito;
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
        if (!ValelaPena() || Vikingos.Count == 0)
            return false;

        double botinTotal = 0;

        foreach (Lugar lugar in Lugares)
        {
            botinTotal += lugar.CalcularBotin();
            lugar.Invadir();
        }

        double botinPorVikingo = botinTotal / Vikingos.Count;
        foreach (Vikingo vikingo in Vikingos)
            vikingo.Oro += botinPorVikingo;

        return true;
    }

    public bool ValeLaPena()
    {
        int cantidadVikingos = CantidadVikingo();

        if (Lugares.Count == 0)
            return false;

        return Lugares.All(lugar => lugar.ValelaPena(cantidadVikingos));
    }

    private bool ValelaPena()
    {
        return ValeLaPena();
    }

    public string ObtenerResumen()
    {
        return $"Expedición: {Nombre}\n" +
               $"Vikingos: {CantidadVikingo()}\n" +
               $"Lugares: {Lugares.Count}\n" +
               $"Vale la pena: {ValeLaPena()}";
    }
}
