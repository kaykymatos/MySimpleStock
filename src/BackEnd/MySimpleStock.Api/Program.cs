using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MySimpleStock.Api.Context;
using MySimpleStock.Api.Endpoints;
using MySimpleStock.Api.Models.ViewModel;
using MySimpleStock.Api.Repositories;
using MySimpleStock.Api.Services;
using MySimpleStock.Api.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<ApplicationDbContextApi>(options =>
                    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Permite qualquer origem
              .AllowAnyMethod() // Permite qualquer método HTTP
              .AllowAnyHeader(); // Permite qualquer cabeçalho
    });
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IValidator<MonthlyProfitReportViewModel>, MonthlyProfitReportValidator>();
builder.Services.AddScoped<IValidator<ProductViewModel>, ProductValidator>();
builder.Services.AddScoped<IValidator<SaleItemViewModel>, SaleItemValidator>();
builder.Services.AddScoped<IValidator<SaleViewModel>, SaleValidator>();
builder.Services.AddScoped<IValidator<ClientViewModel>, ClientValidator>();

builder.Services.AddScoped(typeof(BaseRepository<>)); // Adiciona suporte para repositórios genéricos


builder.Services.AddScoped<IMonthlyProfitReportRepository, MonthlyProfitReportRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISaleItemRepository, SaleItemRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddScoped<IMonthlyProfitReportService, MonthlyProfitReportService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleItemService, SaleItemService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IClientService, ClientService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();


app.MapProductEndpoints()
    .MapSaleEndpoints()
    .MapProfitReportEndpoints()
    .MapClientEndpoints();

app.Run();
