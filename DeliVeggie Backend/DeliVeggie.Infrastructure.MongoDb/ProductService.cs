using DeliVeggie.Shared.Models.Entities;
using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliVeggie.Infrastructure.MongoDb
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _product;
        private readonly IMongoCollection<PriceReduction> _priceReduction;
        public ProductService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("admin");
            _product = database.GetCollection<Product>("Products");
            _priceReduction = database.GetCollection<PriceReduction>("PriceReductions");
        }
        public async Task<List<ProductResponse>> GetAllAsync()
        {
            var filter = Builders<Product>.Filter.Empty;
            var unMappedProducts = await _product.Find(filter).ToListAsync();
            var response = unMappedProducts.Select(x => new ProductResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return response;
        }

        public async Task<ProductDetailsResponse> GetByIdAsync(ProductDetailsRequest request)
        {
            var product = await _product.Find(c => c.Id == request.Id).FirstOrDefaultAsync();
            var filter = Builders<PriceReduction>.Filter.Empty;
            var priceReducationList = await _priceReduction.Find(filter).ToListAsync();

            if (product == null) return null;
            var response = new ProductDetailsResponse
            {
                Id = product.Id,
                Name = product.Name,
                EntryDate = product.EntryDate,
                Price = product.Price,
                PriceReductionList = priceReducationList != null ? priceReducationList.ToList() : null,
            };
            return response;
        }
    }
}
