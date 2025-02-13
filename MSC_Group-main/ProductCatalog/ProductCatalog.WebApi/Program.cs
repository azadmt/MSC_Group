using Framework.Domain.Application;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Product;
using ProductCatalog.Domain;
using ProductCatalog.Domain.Contract;
using ProductCatalog.Persistence;
using ProductCatalog.Persistence.Product;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
        .AddDbContext<ProductCatalogDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddControllers();
// builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ICommandBus,CommandBus>();
builder.Services.AddScoped<ICommandHandler<CreateProductCommand>,CreateProductCommandHandler>();
//builder.Services.AddScoped<ICommandHandler<ActiveProductCommand>,CreateProductCommandHandler>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen();


builder.Services.AddMassTransit(x =>
{
    //x.AddConsumer<ProductCategoryCreatedEventHandler>();
    x.UsingRabbitMq((context, cfg) =>
    {   
        cfg.ConfigureEndpoints(context);

        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
