using Mapster;
using SAEA.DataTransfer.Responses;
using SAEA.Domain.Models;
namespace SAEA.Application.Mapper
{
    public sealed class PavilionMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Pavilion, PavilionResponse>();
        }
    }
}
