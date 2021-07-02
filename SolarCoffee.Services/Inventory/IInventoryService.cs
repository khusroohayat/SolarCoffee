using System.Collections.Generic;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Services.Inventory
{
    public interface IInventoryService
    {
         public List<ProductInventory> GetCurrentInventory();
         public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment);
         public ProductInventory GetProductById(int productid);
         public List<ProdunctInventorySnapshot> GetSnapshotHistory();
    }
}