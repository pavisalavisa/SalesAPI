using System.Threading.Tasks;
using Application.Common;
using Application.Sales.Commands.CreateSale;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
#pragma warning disable 1573

namespace Api.Controllers
{
    /// <summary>
    /// Sale related controller actions. 
    /// </summary>
    public class SalesController : BaseController
    {
        /// <summary>
        /// Creates a sale for given article with given price.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /sales
        ///     {
        ///        "articleNumber": "000001",
        ///        "price": 10.05
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Create sale request model</param>
        /// <returns>Id of newly created sale</returns>
        /// <response code ="201">Returns the id of newly created sale</response>
        /// <response code ="400">All properties are required. Article number is 32 characters or less. Price has to be a positive value.</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EntityCreatedModel>> Create([FromServices] ICreateSaleCommand command, [FromBody]CreateSaleModel model)
        {
            // Route omitted for simplicity sake
            return Created(string.Empty, await command.Execute(model));
        }
    }
}

