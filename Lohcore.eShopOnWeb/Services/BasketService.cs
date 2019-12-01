﻿using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using System.Linq;
using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate;
using Meta.Domain;
using Microsoft.Extensions.Logging;

namespace Lohcode.eShopOnWeb
{
    public class BasketService 
    {
        private readonly IRepository<Basket> _basketRepository;
        private readonly ILogger<BasketService> _logger;

        public BasketService(IRepository<Basket> basketRepository, ILogger<BasketService> logger)
        {
            _basketRepository = basketRepository;
            _logger = logger;
        }

        public async Task Post(AddItemToBasket command)
        {
            var basket = await _basketRepository.GetById(command.BasketId);

            basket.AddItem(command.CatalogItemId, command.Price, command.Quantity);

            await _basketRepository.Update(basket);
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await _basketRepository.GetById(basketId);
            await _basketRepository.Delete(basket);
        }

        public async Task<int> GetBasketItemCountAsync(string userName)
        {
            Guard.Against.NullOrEmpty(userName, nameof(userName));
            var basketSpec = new BasketWithItemsSpecification(userName);
            var basket = (await _basketRepository.ListAsync(basketSpec)).FirstOrDefault();
            if (basket == null)
            {
                _logger.LogInformation($"No basket found for {userName}");
                return 0;
            }
            int count = basket.Items.Sum(i => i.Quantity);
            _logger.LogInformation($"Basket for {userName} has {count} items.");
            return count;
        }

        public async Task SetQuantities(int basketId, Dictionary<string, int> quantities)
        {
            Guard.Against.Null(quantities, nameof(quantities));
            var basket = await _basketRepository.GetByIdAsync(basketId);
            Guard.Against.NullBasket(basketId, basket);
            foreach (var item in basket.Items)
            {
                if (quantities.TryGetValue(item.Id.ToString(), out var quantity))
                {
                    if(_logger != null) _logger.LogInformation($"Updating quantity of item ID:{item.Id} to {quantity}.");
                    item.Quantity = quantity;
                }
            }
            basket.RemoveEmptyItems();
            await _basketRepository.UpdateAsync(basket);
        }

        public async Task TransferBasketAsync(string anonymousId, string userName)
        {
            Guard.Against.NullOrEmpty(anonymousId, nameof(anonymousId));
            Guard.Against.NullOrEmpty(userName, nameof(userName));
            var basketSpec = new BasketWithItemsSpecification(anonymousId);
            var basket = (await _basketRepository.ListAsync(basketSpec)).FirstOrDefault();
            if (basket == null) return;
            basket.BuyerId = userName;
            await _basketRepository.UpdateAsync(basket);
        }
    }
}