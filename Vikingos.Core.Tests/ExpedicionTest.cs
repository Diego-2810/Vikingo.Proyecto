using Xunit;
using Vikingos.Core;
using Vikingos.Core.Interfaces;
using Vikingos.Core.Entidades;

namespace Vikingos.Tests;

public class ExpedicionTest
{
    [Fact]
    public void PuedosAgregarVariosVikingos()
    {
        var expedicion = new Expedicion("Invasión");
        var v1 = new Vikingo("V1", new Karl(), new Soldado()) { VidasCobradas = 25, Armas = 5 };
        var v2 = new Vikingo("V2", new Karl(), new Soldado()) { VidasCobradas = 30, Armas = 3 };

        expedicion.SubirVikingo(v1);
        expedicion.SubirVikingo(v2);

        Assert.Equal(2, expedicion.CantidadVikingo());
    }

    [Fact]
    public void LaExpedicionValelapena()
    {
        var expedicion = new Expedicion("Invasión");
        expedicion.SubirVikingo(new Vikingo("V1", new Karl(), new Soldado()) 
        { 
            VidasCobradas = 25, 
            Armas = 5 
        });

        var aldea = new Aldea("Aldea", 20);
        expedicion.AgregarLugar(aldea);

        Assert.True(expedicion.RealizarExpedicion());
    }
}