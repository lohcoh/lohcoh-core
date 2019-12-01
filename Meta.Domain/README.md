This project is a meta-model of lohcode's DDD.Classic application model.  

This model was originally derived from the 
[eShopOnWeb sample application](https://github.com/dotnet-architecture/eShopOnWeb) 
and has since been evolved somewhat.

## Design Decisions

Some of the most significant design decisions are documented here.

### Dependencies on ASP.NET Core

One design decision was to create interfaces for application fucntions like 
logging, configuration, persistence, and so on, or depend directly on ASP.NET Core API's.

These functions should be modeled when it's desired to be able to replace them, 
but lohcode is meant to be a minimally viable product, the thinnest possible layer over 
the native ASP.NET Core APIs as possible.
Therefore the first version will definitely be bound to ASP.NET Core APIs as much as is practical 
and will probably stay that way.

### Services vs Commands

The CQRS pattern is useful, but adds complexity to the metamodel.
lohcode can/will eventually have more than one metamodel.
Developers will eventually be able to choose between metamodels.
For the first cut, the simplist possible model of a standard DDD application will be used.

#### Possible model options, for future.
- CQRS Pattern
- Microservices
- Container-based

### Marker interfaces vs Attributes

In the .NET world, Attributes are preferred over marker interfaces.
However, I would prefer the type safety that comes with interfaces, so I have 
opted to use marker interfaces to identify the model parts in code.

#### How marker interfaces are used
The interfaces defined in Lohcode's metamodel can be segregated into two categories...
- The model interface defines an application part that can be implemented by the framework.
- The model framework defines an application part that MUST be implemented by a developer.

Application services are application parts that MUST be implemented by a developer.
Application services are modeled in the lohcode metamodel like so...

    /// <summary>
    /// marker interface for application service interface.
    /// </summary>
    public interface IApplicationService {  }

	/// <summary>
    /// The metamodel part for an application service implements this interface.
    /// </summary>
    public interface IApplicationService<TInterface, TImplementation> : IApplication
    {
        Type InterfaceType { get; }
        Type ImplementationType { get; }

        /// <summary>
        /// Returns the set of methods from the service interface that represent queries
        /// </summary>
        IReadOnlyCollection<MethodInfo> Queries { get; }

        /// <summary>
        /// Returns the set of methods from the service interface that represent mutations
        /// </summary>
        IReadOnlyCollection<MethodInfo> Mutations { get; }

    }

An application service is implemented in lohcode like so...

	public interface IOrderService : IApplicationService
    {
        Task CreateOrderAsync(int basketId, Address shippingAddress);
    }

    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Basket> _basketRepository;
        private readonly IRepository<CatalogItem> _itemRepository;

        public OrderService(IRepository<Basket> basketRepository,
            IRepository<CatalogItem> itemRepository,
            IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _itemRepository = itemRepository;
        }

        public async Task CreateOrderAsync(int basketId, Address shippingAddress)
        {
            var basket = await _basketRepository.GetById(basketId);
            Guard.Against.NullBasket(basketId, basket);
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var catalogItem = await _itemRepository.GetByIdAsync(item.CatalogItemId);
                var itemOrdered = new CatalogItemOrdered(catalogItem.Id, catalogItem.Name, catalogItem.PictureUri);
                var orderItem = new OrderItem(itemOrdered, item.UnitPrice, item.Quantity);
                items.Add(orderItem);
            }
            var order = new Order(basket.BuyerId, shippingAddress, items);

            await _orderRepository.AddAsync(order);
        }
    }

	At runtime, lohcode creates objects that implement all the parts of the application metamodel and connects all those parts together.
	The service implementation, created by a developer, implements the IApplicationService marker interface.
	The model will have a corresponding object that wraps the implementation object and implements the IApplicationService<TInterface, TImplementation> interface.
	

