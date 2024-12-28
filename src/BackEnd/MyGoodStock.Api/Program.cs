using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyGoodStock.Api.Context;
using MyGoodStock.Api.Endpoints;
using MyGoodStock.Api.Models.ViewModel;
using MyGoodStock.Api.Repositories;
using MyGoodStock.Api.Services;
using MyGoodStock.Api.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<ApplicationDbContextApi>(options =>
                    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IValidator<MonthlyProfitReportViewModel>, MonthlyProfitReportValidator>();
builder.Services.AddScoped<IValidator<ProductViewModel>, ProductValidator>();
builder.Services.AddScoped<IValidator<SaleItemViewModel>, SaleItemValidator>();
builder.Services.AddScoped<IValidator<SaleViewModel>, SaleValidator>();
builder.Services.AddScoped<IValidator<ClientViewModel>, ClientValidator>();

builder.Services.AddScoped(typeof(BaseRepository<>)); // Adiciona suporte para reposit�rios gen�ricos


builder.Services.AddScoped<IMonthlyProfitReportRepository, MonthlyProfitReportRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISaleItemRepository, SaleItemRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();

builder.Services.AddScoped<IMonthlyProfitReportService, MonthlyProfitReportService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleItemService, SaleItemService>();
builder.Services.AddScoped<ISaleService, SaleService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapProductEndpoints()
    .MapSaleEndpoints()
    .MapProfitReportEndpoints();

app.Run();
