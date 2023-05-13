using MediatR;
using Product.API.Data;

namespace Product.API.CQRS.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly ProductDbContext context;

        public CreateProductCommandHandler(ProductDbContext context)
        {
            this.context = context;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var addedProduct = new Data.Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
            };
            await this.context.Products.AddAsync(addedProduct);
            await this.context.SaveChangesAsync();

            return new CreateProductResult
            {
                Id = addedProduct.Id,
            };
        }
    }
}
