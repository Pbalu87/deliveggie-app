using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using System;
using System.Threading.Tasks;

namespace DeliVeggie.Infrastructure.RabbitMQ
{
    public interface IPublisher
    {
       Task<IResponse> RequestAsync(IRequest request);
    }
}