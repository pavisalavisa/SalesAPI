using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Reports.Queries.GetDailyRevenue;
using Application.Reports.Queries.GetDailySoldArticles;
using Application.Reports.Queries.GetRevenuePerArticle;
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
        public async Task<ActionResult<IEnumerable<DailyRevenueModel>>> GetDailyRevenue(
            [FromServices] IGetDailyRevenueQuery query)
        {
            return Ok(await query.Execute());
        }

        [HttpGet]
        [Route("revenue-per-article")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DailyRevenueModel>>> GetRevenuePerArticle(
            [FromServices] IGetRevenuePerArticleQuery query)
        {
            return Ok(await query.Execute());
        }

        [HttpGet]
        [Route("daily-sold-articles")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DailyRevenueModel>>> GetDailySoldArticles(
            [FromServices] IGetDailySoldArticlesQuery query)
        {
            return Ok(await query.Execute());
        }
    }
}