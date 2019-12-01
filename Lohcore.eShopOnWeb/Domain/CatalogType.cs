

using Meta.Domain;

namespace Lohcode.eShopOnWeb
{
    public class CatalogType : BaseEntity, IAggregateRoot
    {
        public string Type { get; set; }
    }
}
