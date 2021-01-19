using System.Threading.Tasks;
using Application.Common;

namespace Application.Sales.Commands.CreateSale
{
    public interface ICreateSaleCommand
    {
        Task<EntityCreatedModel> Execute(CreateSaleModel model);
    }
}