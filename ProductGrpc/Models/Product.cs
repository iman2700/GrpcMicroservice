namespace ProductGrpc.Models
{
    public class Product
    {
        public int PeoductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public ProductStatus Staus { get; set; }
        public DateTime CreateTime { get; set; }
    }
    public enum ProductStatus
    {
        INSTOCK=0,
        LOW=1,
        NONE=2
    }
}
