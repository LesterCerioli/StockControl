namespace StockControl.Infrastructure.Product.Models
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
         
    }
}