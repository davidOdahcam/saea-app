using Microsoft.AspNetCore.Mvc;
using SAEA.Application.Services.Interfaces;
using SAEA.DataTransfer.Responses;

namespace SAEA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PavilionController(IPavilionAppService pavilionAppService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PavilionResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetListPavilionsAsync()
        {
            return Ok(await pavilionAppService.GetListPavilionsAsync());
        }

        [HttpGet("{id}/Availability")]
        [ProducesResponseType(typeof(DateAvailabilityResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDateAvailabilityByPavilionIdAsync(Guid id)
        {
            return Ok(await pavilionAppService.GetDateAvailabilityByPavilionIdAsync(id));
        }
    }
}
