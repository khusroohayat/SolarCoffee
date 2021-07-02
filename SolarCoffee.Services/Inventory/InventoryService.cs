using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolarCoffee.Data;
using SolarCoffee.Data.Models;
using Microsoft.Extensions.Logging;

namespace SolarCoffee.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly SolarDbContext _db;
        private readonly ILogger<InventoryService> _logger;

        public InventoryService(SolarDbContext dbContext, ILogger<InventoryService> logger)
        {
            _db = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Returns All Current Inventory
        /// </summary>
        /// <returns></returns>
        public List<ProductInventory> GetCurrentInventory()
        {
            return _db.ProductInventories
                    .Include(pi => pi.Product)
                    .Where(pi => !pi.Product.IsArchived)
                    .ToList();
        }

        /// <summary>
        /// Gets a Product Inventory instance by Product ID
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public ProductInventory GetProductById(int productid)
        {
            return _db.ProductInventories
                    .Include(pi => pi.Product)
                    .FirstOrDefault(pi => pi.Product.Id == productid);
        }

        /// <summary>
        /// Rturns Snapshot history for the previous 6 hours
        /// </summary>
        /// <returns></returns>
        public List<ProdunctInventorySnapshot> GetSnapshotHistory()
        {
            var  earliest = DateTime.UtcNow - TimeSpan.FromHours(6);

            return _db.ProdunctInventorySnapshots
                    .Include(snap => snap.Product)
                    .Where(snap
                        => snap.SnapshotTIme > earliest
                        && !snap.Product.IsArchived)
                    .ToList();
        }

        /// <summary>
        /// Updates number of units available of the provided product id
        /// Adjusts QuantityOnHand by adjustment value
        /// </summary>
        /// <param name="id">product id</param>
        /// <param name="adjustment">number of units added / removed from inventory</param>
        /// <returns></returns>
        public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment)
        {
            var now = DateTime.UtcNow;

            try
            {
                var inventory = _db.ProductInventories
                        .Include(inv => inv.Product)
                        .First(inv => inv.Product.Id == id);

                inventory.QuantityOnHand += adjustment;

                _db.SaveChanges();

                try
                {
                    CreateSnapshot(inventory);
                }
                catch (Exception e)
                {
                    _logger.LogError("error creating inventory snapshot.");
                    _logger.LogError(e.StackTrace);
                }

                return new ServiceResponse<ProductInventory> {
                    IsSucces = true,
                    Data = inventory,
                    Message = $"Product {id} inventory adjusted",
                    Time = now
                };
            }
            catch
            {
                return new ServiceResponse<ProductInventory> {
                    IsSucces = false,
                    Data = null,
                    Message = $"Error updating Product Inventory Quantity on Hand",
                    Time = now
                };
            }
        }
    
        /// <summary>
        /// Create a Snapshot Record using the provided Product Inventory instance
        /// </summary>
        /// <param name="inventory"></param>
        private void CreateSnapshot(ProductInventory inventory)
        {
            var now = DateTime.UtcNow;

            var snapshot = new ProdunctInventorySnapshot {
                SnapshotTIme = now,
                Product = inventory.Product,
                QuantityOnHand = inventory.QuantityOnHand
            };

            _db.Add(snapshot);
        }

    }
}