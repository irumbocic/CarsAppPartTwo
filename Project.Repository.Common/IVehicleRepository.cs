using System.Threading.Tasks;

namespace Project.Repository.Common

{
    public interface IVehicleRepository<T>
    {
        Task<T> CreteAsync(T newItem);
        Task<T> DeleteAsync(int id);
        Task<T> GetAsync(int id);
        Task<T> UpdateAsync(T updatedItem);
    }
}