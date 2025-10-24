using SAEA.Domain.Models;

namespace SAEA.Domain.Services.Interfaces
{
    public interface IPavilionService
    {
        Task<IEnumerable<Pavilion>> GetListAsync();
    }
}
