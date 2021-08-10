using System;
using System.Collections.Generic;

namespace Bamboo.Application.Features.Product.ViewModel
{
    public class ProductVM     {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Catalog
    {
        public List<Brand> Brands { get; set; } = new List<Brand>();
    }


    public class Price
    {
        public double min { get; set; }
        public double max { get; set; }
        public string currencyCode { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public double minFaceValue { get; set; }
        public double maxFaceValue { get; set; }
        public int? count { get; set; }
        public Price price { get; set; }
        public DateTime modifiedDate { get; set; }
    }

    public class Brand
    {
        public string name { get; set; }
        public string countryCode { get; set; }
        public string currencyCode { get; set; }
        public string description { get; set; }
        public object disclaimer { get; set; }
        public string redemptionInstructions { get; set; }
        public string terms { get; set; }
        public string logoUrl { get; set; }
        public DateTime modifiedDate { get; set; }
        public List<Product> products { get; set; }
    }

    public class OrderProductVM
    {
        public string productId { get; set; }
        public int quantity { get; set; }
        public decimal value { get; set; }
    }
}
