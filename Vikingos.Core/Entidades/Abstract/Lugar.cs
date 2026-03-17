namespace Vikingos.Core.Entidades.Abstract;

public abstract class Lugar
{
    public string Nombre { get; set; }
    public int Defensores { get; set; }

    protected Lugar(string nombre, int defensores)
    {
        Nombre = nombre;
        Defensores = defensores;
    }

    public abstract bool ValelaPena(int cantidadVikingos);
    public abstract double CalcularBotin();

    public virtual void Invadir()
    {
        Defensores = 0;
    }
}
