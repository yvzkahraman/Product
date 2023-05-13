using MediatR;

namespace Product.API.CQRS.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
    }
}
