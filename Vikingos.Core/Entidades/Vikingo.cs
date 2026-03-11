using Vikingos.Core.Interfaces;
using Vikingos.Core.Entidades.Abstract;

namespace Vikingos.Core.Entidades;

public class Vikingo
{
    public string Nombre { get; set; }
    public CastaSocial Casta { get; set; }
    public Rol Rol { get; set; }
    
    public int VidasCobradas { get; set; }
    public int Armas { get; set; }
    
    public int Hijos { get; set; }
    public int Hectareas { get; set; }

    public Vikingo(string nombre, CastaSocial casta, Rol rol)
    {
        Nombre = nombre;
        Casta = casta;
        Rol = rol;
        VidasCobradas = 0;
        Armas = 0;
        Hijos = 0;
        Hectareas = 0;
    }

    public bool EsProductivo()
    {
        return Rol.EsProductivo(this);
    }

    public bool PuedeIrAExpedicion()
    {
        if (Casta is Jarl && Armas > 0)
            return false;

        return EsProductivo();
    }

    public void Ascender()
    {
        Casta.Ascender(this);
    }
}
