using Xunit;
using Vikingos.Core;
using Vikingos.Core.Interfaces;
using Vikingos.Core.Entidades;

namespace Vikingos.Tests;

public class SoldadoTest
{
    [Fact]
    public void UnSoldadoProductivoPuedeSUbir()
    {
        var expedicion = new Expedicion("Invasión de París");
        var vikingo = new Vikingo("Ragnar", new Karl(), new Soldado())
        {
            VidasCobradas = 25,
            Armas = 5
        };

        bool resultado = expedicion.SubirVikingo(vikingo);

        Assert.True(resultado);
        Assert.Single(expedicion.Vikingos);
    }

    [Fact]
    public void UnSoldadoSinArmasNoSubE()
    {
        var expedicion = new Expedicion("Invasión de París");
        var vikingo = new Vikingo("Erik", new Karl(), new Soldado())
        {
            VidasCobradas = 25,
            Armas = 0
        };

        bool resultado = expedicion.SubirVikingo(vikingo);

        Assert.False(resultado);
        Assert.Empty(expedicion.Vikingos);
    }
}
