using MediatR;

namespace Product.API.CQRS.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductResult> 
    {
        public int Price { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
    }

    public class CreateProductResult
    {
        public int Id { get; set; }
    }
}
