using SAEA.Domain.Models;
using SAEA.Domain.Repositories;
using SAEA.Infrastructure.Database.Context;

namespace SAEA.Infrastructure.Repositories
{
    public sealed class OperatingBlockRepository(SAEAContext context) : Repository<OperatingBlock>(context), IOperatingBlockRepository
    {
    }
}
