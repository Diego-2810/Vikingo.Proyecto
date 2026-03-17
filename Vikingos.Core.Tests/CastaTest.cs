using Xunit;
using Vikingos.Core;
using Vikingos.Core.Interfaces;
using Vikingos.Core.Entidades;

namespace Vikingos.Tests;

public class CastaTest
{
    [Fact]
    public void UnJarlConArmasNoSubE()
    {
        var expedicion = new Expedicion("Invasión de París");
        var vikingo = new Vikingo("Esclavo", new Jarl(), new Soldado())
        {
            VidasCobradas = 25,
            Armas = 2
        };

        bool resultado = expedicion.SubirVikingo(vikingo);

        Assert.False(resultado);
    }

    [Fact]
    public void AscensoDeJarlAKarl()
    {
        var vikingo = new Vikingo("Thralle", new Jarl(), new Soldado())
        {
            Armas = 0
        };

        vikingo.Ascender();

        Assert.IsType<Karl>(vikingo.Casta);
        Assert.Equal(10, vikingo.Armas);
    }

    [Fact]
    public void AscensoDeKarlAThrall()
    {
        var vikingo = new Vikingo("Karl", new Karl(), new Soldado())
        {
            Armas = 5
        };

        vikingo.Ascender();

        Assert.IsType<Thrall>(vikingo.Casta);
    }
    [Fact]
    public void RagnarSiendoKarlEscalaCorrectamenteAThrall()
    {
        var ragnar = new Vikingo("Ragnar", new Karl(), new Soldado())
        {
            VidasCobradas = 35,
            Armas = 6
        };

        ragnar.Ascender();

        Assert.IsType<Thrall>(ragnar.Casta);
    }

}
