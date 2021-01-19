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
        /// <summary>
        /// Gets revenue for each day. Empty list will be returned if there are no sales.
        /// </summary>
        /// <returns>List containing revenue for every date that had a sale.</returns>
        /// <response code="200">List containing revenue for every date that had a sale.</response>
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

        /// <summary>
        /// Gets total revenue for each article. Empty list will be returned if there are no sales.
        /// </summary>
        /// <returns>List containing revenue for every article that was sold.</returns>
        /// <response code="200">List containing revenue for every article that was sold.</response>
        [HttpGet]
        [Route("revenue-per-article")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DailyRevenueModel>>> GetRevenuePerArticle(
            [FromServices] IGetRevenuePerArticleQuery query)
        {
            return Ok(await query.Execute());
        }

        /// <summary>
        /// Gets number of sold articles for each day that had any articles sold. Empty list will be returned if there are no sales.
        /// </summary>
        /// <returns>List containing number of sold articles for every date that had a sale.</returns>
        /// <response code="200">List containing number of sold articles for every date that had a sale</response>
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