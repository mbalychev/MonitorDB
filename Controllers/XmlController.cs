using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitorDB.Models;
using MonitorDB.Readers;
using Pp.Common.Db;
using Pp.Common.FilesDb.Models;

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