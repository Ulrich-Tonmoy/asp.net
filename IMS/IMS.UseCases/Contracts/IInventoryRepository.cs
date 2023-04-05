using IMS.CoreBusiness;

namespace IMS.UseCases.Contracts
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
    }
}
