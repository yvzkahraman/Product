using MediatR;
using Entity = Product.API.Data;

namespace Product.API.CQRS.GetProducts
{
    public class GetProductsQuery : IRequest<List<Entity.Product>>
    {
    }
}
