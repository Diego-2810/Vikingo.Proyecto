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

        Assert.True(expedicion.ValeLaPena());
    }

    [Fact]
    public void AlIntentarSubirYNoPoderDebeAvisarYNoAgregar()
    {
        var expedicion = new Expedicion("Invasión");
        var vikingo = new Vikingo("Erik", new Karl(), new Soldado())
        {
            VidasCobradas = 10,
            Armas = 0
        };

        var resultado = expedicion.IntentarSubirVikingo(vikingo);

        Assert.False(resultado.Exito);
        Assert.Contains("no puede subir", resultado.Mensaje);
        Assert.Equal(0, expedicion.CantidadVikingo());
    }

    [Fact]
    public void SiNoHayLugaresLaExpedicionNoValeLaPena()
    {
        var expedicion = new Expedicion("Invasión");
        expedicion.SubirVikingo(new Vikingo("V1", new Karl(), new Soldado())
        {
            VidasCobradas = 25,
            Armas = 5
        });

        Assert.False(expedicion.ValeLaPena());
    }

    [Fact]
    public void RealizarExpedicionInvadeYLuegoReparteBotinEquitativamente()
    {
        var expedicion = new Expedicion("Invasión");
        var v1 = new Vikingo("Ragnar", new Karl(), new Soldado()) { VidasCobradas = 30, Armas = 4 };
        var v2 = new Vikingo("Ivar", new Thrall(), new Soldado()) { VidasCobradas = 27, Armas = 3 };

        expedicion.SubirVikingo(v1);
        expedicion.SubirVikingo(v2);

        var aldea = new Aldea("Aldea", 20); // 20 de botín
        var capital = new Capital("París", 100, 1.0); // 100 de botín
        expedicion.AgregarLugar(aldea);
        expedicion.AgregarLugar(capital);

        bool realizada = expedicion.RealizarExpedicion();

        Assert.True(realizada);
        Assert.Equal(60, v1.Oro);
        Assert.Equal(60, v2.Oro);
        Assert.Equal(0, aldea.Crucifijos);
        Assert.Equal(0, capital.Defensores);
    }
}
