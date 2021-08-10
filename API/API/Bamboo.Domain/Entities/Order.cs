using System.Collections.Generic;

namespace Bamboo.Domain.Entities
{
    public class Order
    {
        public string RequestID { get; set; }
        public string AccountId { get; set; }
        public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();
    }

    public class OrderEntity
    {
        public string RequestID { get; set; }
        public string AccountId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }


}
