using IMS.Data;
using IMS.Service.Contracts;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory() {InventoryId=1,InventoryName="Bike",Quantity=10,Price=1},
                new Inventory() {InventoryId=1,InventoryName="Car",Quantity=20,Price=5},
                new Inventory() {InventoryId=1,InventoryName="Super Car",Quantity=5,Price=20},
                new Inventory() {InventoryId=1,InventoryName="Yacht",Quantity=5,Price=40},
            };
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories.ToList());

            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}