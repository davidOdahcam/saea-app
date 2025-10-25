using Mapster;
using SAEA.DataTransfer.Responses;
using SAEA.Domain.Models;

namespace SAEA.Application.Mapper
{
    public sealed class AvailabilityMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DateAvailability, DateAvailabilityResponse>();
        }
    }
}
