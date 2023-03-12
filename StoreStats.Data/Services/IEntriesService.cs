using StoreStats.Data.Models;
using System.Threading.Tasks;

namespace StoreStats.Data.Services
{
    public interface IEntriesService
    {
        Task<CreateEntryResponse> PostEntryAsync(CreateEntryDto entry);
    }
}