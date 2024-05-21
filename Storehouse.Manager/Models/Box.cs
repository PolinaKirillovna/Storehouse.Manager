using Storehouse.Manager.Exceptions;

namespace Storehouse.Manager.Models;

public class Box : StorehouseItem
{
    public DateTime? ProductionDate { get; private set; }
    public DateTime ExpiryDate { get; private set; }
    public override double Weight { get; }
    
    public Box(double width, double height, double depth, double weight, DateTime productionDate)
        : base(width, height, depth)
    {
        Weight = weight;
        ProductionDate = productionDate;
        ExpiryDate = productionDate.AddDays(100); 
    }
    
    public Box(double width, double height, double depth, double weight, DateTime? productionDate, DateTime expiryDate)
        : base(width, height, depth)
    {
        if (productionDate == null && expiryDate == default(DateTime))
        {
            throw BoxException.MissingProductionOrExpiryDate();
        }

        Weight = weight;
        ProductionDate = productionDate;
        ExpiryDate = productionDate.HasValue ? productionDate.Value.AddDays(100) : expiryDate;
    }
}