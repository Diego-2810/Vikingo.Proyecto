using Xunit;
using Vikingos.Core;
using Vikingos.Core.Interfaces;
using Vikingos.Core.Entidades;

namespace Vikingos.Tests;

public class GranjeroTest
{
    [Fact]
    public void UnGranjeroProductivoPuedSubir()
    {
        var expedicion = new Expedicion("Invasión de París");
        var vikingo = new Vikingo("Lagertha", new Karl(), new Granjero())
        {
            Hijos = 3,
            Hectareas = 6
        };

        bool resultado = expedicion.SubirVikingo(vikingo);

        Assert.True(resultado);
        Assert.Single(expedicion.Vikingos);
    }

    [Fact]
    public void UnGranjeroSinHectareasNoSube()
    {
        var expedicion = new Expedicion("Invasión de París");
        var vikingo = new Vikingo("Campesino", new Karl(), new Granjero())
        {
            Hijos = 4,
            Hectareas = 5
        };

        bool resultado = expedicion.SubirVikingo(vikingo);

        Assert.False(resultado);
    }
}
