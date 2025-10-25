using SAEA.Domain.Models;
using SAEA.Domain.Repositories;
using SAEA.Infrastructure.Database.Context;

namespace SAEA.Infrastructure.Repositories
{
    public sealed class OperatingHourRepository(SAEAContext context) : Repository<OperatingHour>(context), IOperatingHourRepository
    {
    }
}
