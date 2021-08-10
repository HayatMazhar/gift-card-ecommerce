using System.Collections.Generic;

namespace Bamboo.Application.Features.Order.ViewModel
{
    public class OrderVM 
    {
        public string RequestID { get; set; }
        public string AccountId { get; set; }
        public List<Product.ViewModel.Product> Products { get; set; } = new List<Product.ViewModel.Product>();
    }

}
