

using Meta.Domain;

namespace Lohcode.eShopOnWeb
{
    public class CatalogBrand : BaseEntity, IAggregateRoot
    {
        public string Brand { get; set; }
    }
}
