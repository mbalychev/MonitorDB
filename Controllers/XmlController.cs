using Microsoft.AspNetCore.Mvc;
using MonitorDB.Readers;

namespace MonitorDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlController : ControllerBase
    {
        private readonly ReadXmlErrors errors;
        public XmlController(
            ReadXmlErrors errors)
        {
            this.errors = errors;
        }

        [HttpGet("Errors")]
        public async Task<ActionResult<IEnumerable<ErrorsQueryResults>>> GetTModels()
        {
            return Ok(await errors.Read());

            // return new List<TModel> { };
        }


    }
}