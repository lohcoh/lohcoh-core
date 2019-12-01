using Meta.Domain;

namespace Lohcode.eShopOnWeb
{
    /// <summary>
    /// NOTE: By implementing IApplicationCommnd
    /// </summary>
    public class AddItemToBasket : IDomainCommand, IApplicationCommand
    {
        public int BasketId { get; }
        public int CatalogItemId { get; }
        public decimal Price { get; }
        public int Quantity { get; } = 1;

        public AddItemToBasket(int basketId, int catalogItemId, decimal price, int quantity = 1) 
        {
            this.BasketId= basketId;
            this.CatalogItemId= catalogItemId;
            this.Price= price;
            this.Quantity= quantity;
        }
    }
}