using IMS.Data;

namespace IMS.Service.Inventories.Contracts
{
    public interface IInventoryService
    {
        Task AddInventoryAsync(Inventory inventory);
        Task EditEnventoryAsync(Inventory inventory);
        Task<IEnumerable<Inventory>> GetInventoryByNameAsync(string name = "");
        Task<Inventory> GetInventoryByIdAsync(int id);
    }
}
