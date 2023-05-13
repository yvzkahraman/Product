using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Entity = Product.API.Data;
namespace Product.API.CQRS.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Entity.Product?>
    {
        private readonly ProductDbContext context;

        public GetProductQueryHandler(ProductDbContext context)
        {
            this.context = context;
        }

        public async Task<Entity.Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await this.context.Products.AsNoTracking().SingleOrDefaultAsync(x=>x.Id == request.Id);
            return product;
        }
    }
}
