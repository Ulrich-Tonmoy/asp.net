using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Service.Sorting.Contracts;

namespace EmployeeManagementSystem.Service.Sorting
{
    public class EmployeeSort : SortHelper<Employee>, IEmployeeSort
    {
    }
}
