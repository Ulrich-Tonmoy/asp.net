using IMS.Data;

namespace IMS.Service.Inventories.Contracts
{
    public interface IViewInventoriesByNameUseCase
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
    }
}