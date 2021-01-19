using System.Threading.Tasks;
using Application.Common;
using Application.Sales.Commands.CreateSale;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class SalesController : BaseController
    {
        /// <summary>
        /// Creates a sale for given article with given price.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST /Sales
        ///     {
        ///         "articleNumber": "000001",
        ///         "price": 10.15
        ///     }
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>Id of newly created sale</returns>
        /// <response code ="201">Returns the id of newly created sale</response>
        /// <response code ="400">All properties are required</response>
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

