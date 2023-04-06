using IMS.Data;
using IMS.Service.Contracts;
using IMS.Service.Inventories.Contracts;

namespace IMS.Service.Inventories
{
    public class ViewInventoriesByNameService : IViewInventoriesByNameUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoriesByNameService(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await inventoryRepository.GetInventoriesByNameAsync(name);
        }
    }
}
