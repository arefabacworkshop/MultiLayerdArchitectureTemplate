using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {

        [HttpGet("{id?}")]
        public async Task<IActionResult> get (int? id)
        {
            return Ok();
        }
    }
}
