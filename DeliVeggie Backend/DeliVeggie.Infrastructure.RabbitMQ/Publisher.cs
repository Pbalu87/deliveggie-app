using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using EasyNetQ;
using System.Threading.Tasks;

namespace DeliVeggie.Infrastructure.RabbitMQ
{
    public class Publisher : IPublisher
    {
        public readonly IBus _bus;

        public Publisher()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
        }

        public async Task<IResponse> RequestAsync(IRequest request)
        {
            return await _bus.Rpc.RequestAsync<IRequest, IResponse>(request);
        }
    }
}