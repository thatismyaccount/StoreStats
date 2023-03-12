using StoreStats.Data.Models;
using System.Threading.Tasks;

namespace StoreStats.Data.Services
{
    public interface IStoresService
    {
        Task<DeleteStoreResponse> DeleteStoreAsync(int id);
        Task<GetStoreResponse> GetStoreAsync(int id);
        Task<PostStoreResponse> PostStoreAsync(CreateStoreDto store);
        Task<PutStoreResponse> PutStoreAsync(int id, PutStoreDto store);
    }
}