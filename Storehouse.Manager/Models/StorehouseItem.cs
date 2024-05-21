namespace Storehouse.Manager.Models;

public abstract class StorehouseItem
{
    protected StorehouseItem(double width, double height, double depth)
    {
        Width = width;
        Height = height;
        Depth = depth;
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    
    public virtual double Weight { get; }

    public virtual double Volume => Depth * Width * Height;
}