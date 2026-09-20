namespace Models
{


    public enum Category
    {
        Electronics,
        Clothing,
        HomeGoods,
        Books,
        Toys
    }
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}