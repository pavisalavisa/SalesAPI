using System.Threading.Tasks;
using Application.Common;
using Application.Common.Contracts;
using Common.DateTime;
using Domain.Entities;
using Domain.Enums;
using Microsoft.Extensions.Logging;

namespace Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand : ICreateSaleCommand
    {
        private readonly ILogger<CreateSaleCommand> _logger;
        private readonly ISalesDbContext _context;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateSaleCommand(ILogger<CreateSaleCommand> logger, ISalesDbContext context,
            IDateTimeProvider dateTimeProvider)
        {
            _logger = logger;
            _context = context;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<EntityCreatedModel> Execute(CreateSaleModel model)
        {
            // Potential questions:
            //  - What if we need to support different currencies?
            //  - What if we have clients with multiple timezones?
            var entity = new Sale
            {
                ArticleNumber = model.ArticleNumber,
                Currency = Currency.Euro,
                DateTimeUtc = _dateTimeProvider.UtcNow,
                Price = model.Price
            };

            await _context.Sales.AddAsync(entity);

            await _context.SaveChangesAsync();

            _logger.LogInformation(
                $"Sale for article {entity.ArticleNumber} was made for {entity.Price} {entity.Currency}");

            return new EntityCreatedModel(entity.Id);
        }
    }
}