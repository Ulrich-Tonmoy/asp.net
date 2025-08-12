﻿namespace eCommerce.Application.DTOs.Product
{
    public class ProductBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Base64Image { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
    }
}
