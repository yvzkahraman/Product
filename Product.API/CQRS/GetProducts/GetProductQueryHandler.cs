using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Entity = Product.API.Data;

namespace Product.API.CQRS.GetProducts
{
    public class GetProductQueryHandler : IRequestHandler<GetProductsQuery, List<Entity.Product>>
    {
        private readonly ProductDbContext context;

        public GetProductQueryHandler(ProductDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Entity.Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await this.context.Products.AsNoTracking().ToListAsync();
            return products;
        }
    }
}
