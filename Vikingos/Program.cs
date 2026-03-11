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

bool r1 = expedicion.SubirVikingo(ragnar);
Console.WriteLine($"{(r1 ? "✓" : "✗")} {ragnar.Nombre} - Soldado, {ragnar.VidasCobradas} vidas, {ragnar.Armas} armas");

bool r2 = expedicion.SubirVikingo(lagertha);
Console.WriteLine($"{(r2 ? "✓" : "✗")} {lagertha.Nombre} - Granjero, {lagertha.Hijos} hijos, {lagertha.Hectareas} hectáreas");

bool r3 = expedicion.SubirVikingo(ivar);
Console.WriteLine($"{(r3 ? "✓" : "✗")} {ivar.Nombre} - Soldado, {ivar.VidasCobradas} vidas, {ivar.Armas} armas");

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
Console.WriteLine($"Vale la pena: {expedicion.RealizarExpedicion()}\n");

// Ascenso
Console.WriteLine("Prueba de ascenso:\n");

var thralle = new Vikingo("Thralle", new Jarl(), new Soldado())
{
    Armas = 0
};

Console.WriteLine($"Antes: {thralle.Nombre} - {thralle.Casta.GetType().Name} - {thralle.Armas} armas");
thralle.Ascender();
Console.WriteLine($"Después: {thralle.Nombre} - {thralle.Casta.GetType().Name} - {thralle.Armas} armas");