using MicroShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MicroShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MicroShop.Order.Application.Interfaces;
using MicroShop.Order.Persistence.Repositories;

using MicroShop.Order.Persistence.Context;
using System.Reflection;
using MicroShop.Order.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.RequireHttpsMetadata = false;
    opt.Audience = "resourceOrder";
});
builder.Services.AddScoped<OrderContext>();

// Add services to the container.
builder.Services.AddScoped<GetAddressQueryHandler>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressCommandHandler>();

builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailQueryHandler>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddAppService(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
