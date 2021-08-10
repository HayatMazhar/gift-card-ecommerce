

namespace Bamboo.Domain.Entities
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Description { get; set; }
    }

    public class OrderProduct 
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
    
}
