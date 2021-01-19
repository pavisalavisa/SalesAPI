using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Reports.Queries.GetDailyRevenue;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ReportsController : BaseController
    {
        [HttpGet]
        [Route("daily-revenue")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DailyRevenueModel>>> GetDailyRevenue([FromServices] IGetDailyRevenueQuery query)
        {
            return Ok(await query.Execute());
        }
    }
}
