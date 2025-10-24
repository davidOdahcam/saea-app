using SAEA.Domain.Models;
using SAEA.Domain.Repositories;
using SAEA.Infrastructure.Database.Context;

namespace SAEA.Infrastructure.Repositories
{
    public sealed class PavilionRepository(SAEAContext context) : Repository<Pavilion>(context), IPavilionRepository
    {
    }
}
