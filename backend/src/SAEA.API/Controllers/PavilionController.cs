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
        [ProducesResponseType(typeof(GetListPavilionsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetListPavilions()
        {
            return Ok(await pavilionAppService.GetListPavilionsAsync());
        }
    }
}
