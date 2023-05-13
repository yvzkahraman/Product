using MediatR;
using Entity = Product.API.Data;
namespace Product.API.CQRS.GetProduct
{
    public class GetProductQuery : IRequest<Entity.Product?>
    {
        public int Id { get; set; }

        public GetProductQuery(int id)
        {
            Id = id;
        }
    }
}
