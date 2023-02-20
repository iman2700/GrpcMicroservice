using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using ProductGrpc.Data;
using ProductGrpc.Models;
using ProductGrpc.Protos;
using ProductStatus = ProductGrpc.Protos.ProductStatus;

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
                Status = ProductStatus.Low,
                Name = product.Name,
            };
            return productModel;
        }
        public override async Task GetAllProduct(GetAllProductsRequest request, IServerStreamWriter<ProductModel> responseStream, ServerCallContext context)
        {
             var productList = await _context.Products.ToListAsync();
            foreach (var product in productList)
            {
                var productModel = new ProductModel
                {
                    CreateTime = Timestamp.FromDateTime(product.CreateTime),
                    ProductId = product.ProductId,
                    Description = product.Description,
                    Price = product.Price,
                    Status = ProductStatus.Instock,
                    Name = product.Name
                };
                await responseStream.WriteAsync(productModel);
            }
        }

        public override async Task<ProductModel> AddProduc(AddProductRequest request, ServerCallContext context)
        {
            var product = new Product
            {
                CreateTime =  request.Product.CreateTime.ToDateTime(),
                ProductId = request.Product.ProductId,
                Description = request.Product.Description,
                Price = request.Product.Price,
                Status = Models.ProductStatus.LOW,
                Name = request.Product.Name
            };
            _context.Products.Add(product);
            _context.SaveChangesAsync();
            var productModel = new ProductModel
            {
                CreateTime = Timestamp.FromDateTime(product.CreateTime),
                ProductId = product.ProductId,
                Description = product.Description,
                Price = product.Price,
                Status = ProductStatus.Instock,
                Name = product.Name
            };
            return productModel;
        }
    }
}
