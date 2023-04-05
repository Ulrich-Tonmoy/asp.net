using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.Contracts
{
    public interface IViewInventoriesByNameUseCase
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
    }
}