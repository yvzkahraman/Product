using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.API.Data;

namespace Product.API.CQRS.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly ProductDbContext context;

        public RemoveProductCommandHandler(ProductDbContext context)
        {
            this.context = context;
        }
        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
           var removedProduct = await this.context.Products.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (removedProduct != null)
            {
                this.context.Products.Remove(removedProduct);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
