using SAEA.Application.Services.Interfaces;
using SAEA.DataTransfer.Responses;
using SAEA.Domain.Services.Interfaces;

namespace SAEA.Application.Services
{
    public sealed class PavilionAppService(
        IPavilionService pavilionService
    ) : IPavilionAppService
    {
        public async Task<GetListPavilionsResponse> GetListPavilionsAsync()
        {
            var list = await pavilionService.GetListAsync();
            return new GetListPavilionsResponse(list);
        }
    }
}
