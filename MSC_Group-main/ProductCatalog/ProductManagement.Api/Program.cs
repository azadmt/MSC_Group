using Framework.Domain.Application;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Api.EventHandler;
using OrderManagement.Application.Order;
using OrderManagement.Domain.Contract;
using OrderManagement.Domain.Order;
using OrderManagement.Persistence;
using OrderManagement.Persistence.Repository;

namespace ProductManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add services to the container.
            // Add services to the container.
            builder.Services
                    .AddDbContext<OrderManagementDbContext>(opt =>
                    opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));


            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<StockAdjusmentConfirmedEventHandler>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureJsonSerializerOptions(options =>
                    {
                        // customize the JsonSerializerOptions here
                        return options;
                    });
                    cfg.ConfigureEndpoints(context);
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICommandBus, CommandBus>();
            builder.Services.AddScoped<ICommandHandler<CreateOrderCommand>, CreateOrderCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<ApproveOrderCommand>, ApproveOrderCommandHandler>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

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
        }
    }
}