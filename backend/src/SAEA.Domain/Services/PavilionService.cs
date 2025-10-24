using SAEA.Domain.Models;
using SAEA.Domain.Repositories;
using SAEA.Domain.Services.Interfaces;

namespace SAEA.Domain.Services
{
    public sealed class PavilionService(IPavilionRepository pavilionRepository) : IPavilionService
    {
        public Task<IEnumerable<Pavilion>> GetListAsync()
        {
            return pavilionRepository.GetAllAsync();
        }
    }
}
