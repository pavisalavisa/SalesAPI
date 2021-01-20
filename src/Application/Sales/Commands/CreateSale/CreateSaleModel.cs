using FluentValidation;

namespace Application.Sales.Commands.CreateSale
{
    public class CreateSaleModel
    {
        public string ArticleNumber { get; set; }
        public decimal Price { get; set; }

        public class CreateSaleModelValidator : AbstractValidator<CreateSaleModel>
        {
            public CreateSaleModelValidator()
            {
                 RuleFor(x => x.ArticleNumber)
                    .NotEmpty().WithMessage("Article number should not be empty.")
                    .MaximumLength(32)
                    .Matches(@"^[0-9a-zA-Z]+$").WithMessage("Article number must contain only alphanumeric characters.");

                // Should the price ever be negative?
                // This is something that PO would usually answer
                RuleFor(x => x.Price)
                    .NotEmpty().WithMessage("Price should not be empty.")
                    .GreaterThan(0);
            }
        }
    }
}