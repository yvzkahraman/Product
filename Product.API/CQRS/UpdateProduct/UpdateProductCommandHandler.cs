using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.API.Data;

namespace Product.API.CQRS.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly ProductDbContext context;

        public UpdateProductCommandHandler(ProductDbContext context)
        {
            this.context = context;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
           var updatedProduct =   await this.context.Products.SingleOrDefaultAsync(x => x.Id == request.Id);

            if(updatedProduct != null) { 
                
                updatedProduct.Name = request.Name;
                updatedProduct.Price = request.Price;
                updatedProduct.Stock = request.Stock;

                await this.context.SaveChangesAsync();
            }

        }
    }
}
