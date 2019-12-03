

using Lohcode.Domain;

namespace Lohcode.eShopOnWeb
{
    [AggregateRoot]
    public class CatalogBrand : EShopOnWebEntity
    {
        public string Brand { get; set; }
    }
}
