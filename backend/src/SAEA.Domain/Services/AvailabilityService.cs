using SAEA.Domain.Enums;
using SAEA.Domain.Repositories;
using SAEA.Domain.Services.Interfaces;
using SAEA.Domain.Models;

namespace SAEA.Domain.Services
{
    public sealed class AvailabilityService(
        IOperatingBlockRepository operatingBlockRepository,
        IOperatingHourRepository operatingHourRepository,
        IPavilionRepository pavilionRepository
    ) : IAvailabilityService
    {
        public async Task<IEnumerable<DateAvailability>> GetDateAvailabilityByPavilionIdAsync(Guid pavilionId, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var pavilion = (await pavilionRepository.FindAsync(x => x.Id == pavilionId)).FirstOrDefault();
            if (pavilion is null) throw new KeyNotFoundException($"Pavilion with ID {pavilionId} not found.");

            var hours = (await operatingHourRepository.FindAsync(x => x.ResourceId == pavilionId && x.ResourceType == EResourceType.PAVILION)).ToList();
            if (hours.Count == 0) throw new Exception($"No operating hours found for Pavilion ID {pavilionId}.");

            var blocks = (await operatingBlockRepository.FindAsync(x => x.ResourceId == pavilionId && x.ResourceType == EResourceType.PAVILION)).ToList();
            
            var totalDays = (endDate - startDate).Days;
            var dayAvailabilities = new List<DateAvailability>();

            for (int i = 0; i <= totalDays; i++)
            {
                var currentDate = startDate.AddDays(i);
                var horarioDia = hours.FirstOrDefault(h => h.DayOfWeek == currentDate.DayOfWeek);

                if (horarioDia is null)
                {
                    dayAvailabilities.Add(new DateAvailability(DateOnly.FromDateTime(currentDate.Date), "Fechado"));
                    continue;
                }

                var operatingStart = new DateTimeOffset(
                    currentDate.Year, currentDate.Month, currentDate.Day,
                    horarioDia.StartTime.Hour, horarioDia.StartTime.Minute, 0,
                    TimeSpan.Zero
                );

                var operatingEnd = new DateTimeOffset(
                    currentDate.Year, currentDate.Month, currentDate.Day,
                    horarioDia.EndTime.Hour, horarioDia.EndTime.Minute, 0,
                    TimeSpan.Zero
                );

                var diaBloqueadoToatalmente = blocks.FirstOrDefault(b =>
                    b.StartDateTime <= operatingStart &&
                    b.EndDateTime >= operatingEnd
                );

                if (diaBloqueadoToatalmente is not null)
                {
                    dayAvailabilities.Add(new DateAvailability(DateOnly.FromDateTime(currentDate.Date), diaBloqueadoToatalmente.Reason ?? "Bloqueado"));
                }
                else
                {
                    dayAvailabilities.Add(new DateAvailability(DateOnly.FromDateTime(currentDate.Date), horarioDia.StartTime, horarioDia.EndTime));
                }
            }

            return dayAvailabilities;
        }
    }
}
