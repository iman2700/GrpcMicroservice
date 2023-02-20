using ProductGrpc.Models;

namespace ProductGrpc.Data
{
    public class ProductsContextSeed
    {
        public static void SeedAsync(ProductsContext productsContext) {
            if (productsContext.Products.Any()) 
            {
                var product = new List<Product>
                {
                     new Product
                     {     PeoductId=1,
                           Name="khfgj",
                           Description="dinnfij",
                           Price=343,
                           Staus= ProductStatus.LOW,
                           CreateTime = DateTime.UtcNow
                     },
                     new Product
                     {     PeoductId=2,
                           Name="khfgj",
                           Description="dinnfij",
                           Price=343,
                           Staus= ProductStatus.LOW,
                           CreateTime = DateTime.UtcNow
                     },
                     new Product
                     {     PeoductId=3,
                           Name="khfwgj",
                           Description="dddddddd",
                           Price=343,
                           Staus= ProductStatus.INSTOCK,
                           CreateTime = DateTime.UtcNow
                     }
                };
                productsContext.Products.AddRange(product);
                productsContext.SaveChanges();
            }
        }
    }
}
