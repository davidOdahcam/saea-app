using SAEA.DataTransfer.Responses;

namespace SAEA.Application.Services.Interfaces
{
    public interface IPavilionAppService
    {
        Task<IEnumerable<PavilionResponse>> GetListPavilionsAsync();
    }
}
