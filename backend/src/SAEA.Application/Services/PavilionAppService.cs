using Mapster;
using Microsoft.Extensions.Configuration;
using SAEA.Application.Services.Interfaces;
using SAEA.DataTransfer.Responses;
using SAEA.Domain.Models;
using SAEA.Domain.Services.Interfaces;

namespace SAEA.Application.Services
{
    public sealed class PavilionAppService(
        IPavilionService pavilionService,
        IAvailabilityService availabilityService,
        IConfiguration config
    ) : IPavilionAppService
    {
        public async Task<IEnumerable<PavilionResponse>> GetListPavilionsAsync()
        {
            var list = await pavilionService.GetListAsync();
            return list.Adapt<IEnumerable<PavilionResponse>>();
        }

        public async Task<IEnumerable<DateAvailabilityResponse>> GetDateAvailabilityByPavilionIdAsync(Guid pavilionId)
        {
            var maxAdvanceBookingDays = config.GetValue<int>("BookingRules:MaxAdvanceBookingDays");
            var startDate = new DateTimeOffset(DateTime.UtcNow.Date, TimeSpan.Zero);
            var endDate = startDate.AddDays(maxAdvanceBookingDays);

            var list = await availabilityService.GetDateAvailabilityByPavilionIdAsync(pavilionId, startDate, endDate);
            return list.Adapt<IEnumerable<DateAvailabilityResponse>>();
        }
    }
}
