namespace DeliVeggie.Microservice.Product.Services
{
    using DeliVeggie.Infrastructure.MongoDb;
    using DeliVeggie.Infrastructure.RabbitMQ;
    using DeliVeggie.Shared.Models.Entities;
    using DeliVeggie.Shared.Models.Requests;
    using DeliVeggie.Shared.Models.Responses;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ProductMessageListener : BackgroundService
    {
        private readonly ISubscriber _subscriber;
        private readonly IProductService _productService;

        public ProductMessageListener(ISubscriber subscriber, IProductService productService)
        {
            _subscriber = subscriber;
            _productService = productService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                _subscriber.Subscribe(HandleRequest);
            }, stoppingToken);
        }

        private IResponse HandleRequest(IRequest arg)
        {
            if (arg is Request<ProductDetailsRequest> detailsRequest)
            {
                var details = Task.Run(async () =>
                {
                    return await _productService.GetByIdAsync(new ProductDetailsRequest { Id = detailsRequest.Data.Id });
                }).GetAwaiter().GetResult();

                var priceDiscount = FindPriceDiscount(details.PriceReductionList);
                details.Price -= priceDiscount;
                IResponse data = new Response<ProductDetailsResponse>() { Data = details };
                return data;
            }
            else
            {
                var details = Task.Run(async () =>
                {
                    return await _productService.GetAllAsync();
                }).GetAwaiter().GetResult();
                IResponse data = new Response<List<ProductResponse>>() { Data = details };
                return data;
            }
        }

        private static double FindPriceDiscount(List<PriceReduction> PriceReductionList)
        {
            var priceReducation = PriceReductionList?.FirstOrDefault(s => s.DayOfWeek == (int)DateTime.Now.DayOfWeek);
            return priceReducation?.Reduction ?? 0;
        }
    }

}
