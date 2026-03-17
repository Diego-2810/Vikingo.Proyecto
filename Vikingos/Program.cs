using Vikingos.Core;
using Vikingos.Core.Interfaces;
using Vikingos.Core.Entidades;

Console.WriteLine("SISTEMA DE EXPEDICIONES VIKINGAS\n");

// Crear una expedición
var expedicion = new Expedicion("Invasión de París");

// Crear vikingos
var ragnar = new Vikingo("Ragnar", new Karl(), new Soldado())
{
    VidasCobradas = 25,
    Armas = 5
};

var lagertha = new Vikingo("Lagertha", new Karl(), new Granjero())
{
    Hijos = 3,
    Hectareas = 6
};

var ivar = new Vikingo("Ivar", new Thrall(), new Soldado())
{
    VidasCobradas = 30,
    Armas = 4
};

// Agregar vikingos a la expedición
Console.WriteLine("Agregando vikingos:\n");

var rvar1 = expedicion.IntentarSubirVikingo(ragnar);
Console.WriteLine($"{(rvar1.Exito ? "✓" : "✗")} {rvar1.Mensaje}");

var rvar2 = expedicion.IntentarSubirVikingo(lagertha);
Console.WriteLine($"{(rvar2.Exito ? "✓" : "✗")} {rvar2.Mensaje}");

var rvar3 = expedicion.IntentarSubirVikingo(ivar);
Console.WriteLine($"{(rvar3.Exito ? "✓" : "✗")} {rvar3.Mensaje}");

// Agregar lugares
Console.WriteLine("\nLugares a invadir:\n");

var aldea = new Aldea("Aldea", 25);
var capital = new Capital("París", 100, 1.5);

expedicion.AgregarLugar(aldea);
expedicion.AgregarLugar(capital);

Console.WriteLine($"Aldea: {aldea.Crucifijos} crucifijos");
Console.WriteLine($"París: {capital.Defensores} defensores\n");

// Resumen
Console.WriteLine("Resumen de la expedición");
Console.WriteLine($"Vikingos: {expedicion.CantidadVikingo()}");
Console.WriteLine($"Vale la pena: {expedicion.ValeLaPena()}");
Console.WriteLine($"Se realizó: {expedicion.RealizarExpedicion()}\n");

// Ascenso
Console.WriteLine("Prueba de ascenso:\n");

var thralle = new Vikingo("Thralle", new Jarl(), new Soldado())
{
    Armas = 0
};

Console.WriteLine($"Antes: {thralle.Nombre} - {thralle.Casta.GetType().Name} - {thralle.Armas} armas");
thralle.Ascender();
Console.WriteLine($"Después: {thralle.Nombre} - {thralle.Casta.GetType().Name} - {thralle.Armas} armas");