using CartApi.Endpoints;
using CartApi.Messaging;
using CartApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection(RabbitMqSettings.SectionName));
builder.Services.AddSingleton<CartService>();
builder.Services.AddSingleton<CartEventPublisher>();
builder.Services.AddHostedService<ProductSelectedConsumer>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapCartEndpoints();

app.Run();
