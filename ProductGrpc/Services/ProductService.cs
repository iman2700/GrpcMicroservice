using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ProductGrpc.Data;
using ProductGrpc.Protos;

namespace ProductGrpc.Services
{
    public class ProductService: ProductProtoService.ProductProtoServiceBase
    {
        private readonly ProductsContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(ProductsContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public override Task<Empty> Test(Empty request , ServerCallContext context) 
        {
          return base.Test(request, context);
        }
        public override async Task<ProductModel> GetProduct(ProductRequest request, ServerCallContext context)
        {
            var product= await _context.Products.FindAsync(request.ProductId);
            var productModel = new ProductModel
            {
                CreateTime = Timestamp.FromDateTime(product.CreateTime),
                ProductId = product.PeoductId,
                Description = product.Description,
                Price = product.Price,
                Status = ProductStatus.Instock,
                Name = product.Name,
            };
            return productModel;
        }
    }
}
