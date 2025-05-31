using DeliVeggie.Shared.Models.Entities;
using System;
using System.Collections.Generic;

namespace DeliVeggie.Shared.Models.Responses
{
    public class ProductDetailsResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double Price { get; set; }
        public List<PriceReduction> PriceReductionList { get; set; }
    }
}