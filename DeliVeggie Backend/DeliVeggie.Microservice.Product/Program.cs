using DeliVeggie.Infrastructure.MongoDb;
using DeliVeggie.Infrastructure.RabbitMQ;
using DeliVeggie.Microservice.Product.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISubscriber, Subscriber>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddHostedService<ProductMessageListener>();
builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
