namespace Vikingos.Core.Entidades;

public class AldeaAmurallada : Aldea
{
    public int MinimovikingosRequeridos { get; set; }

    public AldeaAmurallada(string nombre, int crucifijos, int minimovikingos) 
        : base(nombre, crucifijos)
    {
        MinimovikingosRequeridos = minimovikingos;
    }

    public override bool ValelaPena(int cantidadVikingos)
    {
        return base.ValelaPena(cantidadVikingos) && cantidadVikingos >= MinimovikingosRequeridos;
    }
}
