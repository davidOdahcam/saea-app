using SAEA.Domain.Models;

namespace SAEA.Domain.Services.Interfaces
{
    public interface IAvailabilityService
    {
        Task<IEnumerable<DateAvailability>> GetDateAvailabilityByPavilionIdAsync(Guid pavilionId, DateTimeOffset startDate, DateTimeOffset endDate);
    }
}
