using SAEA.Domain.Models;

namespace SAEA.DataTransfer.Responses
{
    public sealed record GetListPavilionsResponse(IEnumerable<Pavilion> Pavilions);
}
