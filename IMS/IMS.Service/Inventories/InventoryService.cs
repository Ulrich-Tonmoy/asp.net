using IMS.Data;
using IMS.Service.Contracts;
using IMS.Service.Inventories.Contracts;

namespace IMS.Service.Inventories
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            await this.inventoryRepository.AddInventoryAsync(inventory);
        }

        public async Task EditEnventoryAsync(Inventory inventory)
        {
            await inventoryRepository.UpdateInventoryAsync(inventory);
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await inventoryRepository.GetInventoriesByIdAsync(id);
        }

        public async Task<IEnumerable<Inventory>> GetInventoryByNameAsync(string name = "")
        {
            return await inventoryRepository.GetInventoriesByNameAsync(name);
        }
    }
}
