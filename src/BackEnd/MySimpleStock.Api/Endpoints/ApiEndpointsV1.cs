using MySimpleStock.Api.Models.ViewModel;
using MySimpleStock.Api.Services;

namespace MySimpleStock.Api.Endpoints
{
    public static class ApiEndpointsV1
    {
        public static WebApplication MapProductEndpoints(this WebApplication app)
        {
            app.MapPost("/v1/products", async (ProductViewModel product, IProductService _service, HttpContext http) =>
            {
                //var userId = http.User.FindFirst("sub")?.Value;
                //if (userId == null) return Results.Unauthorized();

                //product.UserId = Guid.Parse(userId);

                var res = await _service.CreateAsync(product);

                return res.Success ? Results.Created($"/v1/products/{res.Model.Id}", product) : Results.BadRequest(res);
            });

            app.MapGet("/v1/products/{id:Guid}", async (Guid id, IProductService _service, HttpContext http) =>
            {
                //var userId = http.User.FindFirst("sub")?.Value;
                //if (userId == null) return Results.Unauthorized();

                var products = await _service.GetOneAsync(id, Guid.Parse("cd396dc0-10de-4522-9f63-e5e705032704"));
                if (products == null)
                    return Results.NotFound();
                return Results.Ok(products);
            });
            app.MapGet("/v1/products", async (IProductService _service, HttpContext http) =>
            {
                //var userId = http.User.FindFirst("sub")?.Value;
                //if (userId == null) return Results.Unauthorized();

                var products = await _service.GetAllAsync(Guid.Parse("cd396dc0-10de-4522-9f63-e5e705032704"));
                return Results.Ok(products);
            });

            app.MapPut("/v1/products", async (ProductViewModel product, IProductService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                product.UserId = Guid.Parse(userId);

                var res = await _service.UpdateAsync(product);

                return res.Success ? Results.NoContent() : Results.BadRequest(res);
            });

            app.MapDelete("/v1/products/{id}", async (Guid id, IProductService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                var product = await _service.GetOneAsync(id, Guid.Parse(userId));
                if (product == null) return Results.NotFound();

                var deleteItem = await _service.DeleteAsync(id, Guid.Parse(userId));

                return deleteItem.Success ? Results.NoContent() : Results.BadRequest(deleteItem);
            });

            return app;
        }



        public static WebApplication MapClientEndpoints(this WebApplication app)
        {
            app.MapPost("/v1/clients", async (ClientViewModel product, IClientService _service, HttpContext http) =>
            {
                //var userId = http.User.FindFirst("sub")?.Value;
                //if (userId == null) return Results.Unauthorized();

                //product.UserId = Guid.Parse(userId);

                var res = await _service.CreateAsync(product);

                return res.Success ? Results.Created($"/v1/products/{res.Model.Id}", product) : Results.BadRequest(res);
            });

            app.MapGet("/v1/clients", async (IClientService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                var products = await _service.GetAllAsync(Guid.Parse(userId));
                return Results.Ok(products);
            });

            app.MapGet("/v1/clients/{id:Guid}", async (Guid id, IClientService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                var products = await _service.GetOneAsync(id, Guid.Parse(userId));
                return Results.Ok(products);
            });

            app.MapPut("/v1/clients", async (ClientViewModel product, IClientService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                product.UserId = Guid.Parse(userId);

                var res = await _service.UpdateAsync(product);

                return res.Success ? Results.NoContent() : Results.BadRequest(res);
            });

            app.MapDelete("/v1/clients/{id}", async (Guid id, IClientService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                var product = await _service.GetOneAsync(id, Guid.Parse(userId));
                if (product == null) return Results.NotFound();

                var deleteItem = await _service.DeleteAsync(id, Guid.Parse(userId));

                return deleteItem.Success ? Results.NoContent() : Results.BadRequest(deleteItem);
            });

            return app;
        }


        public static WebApplication MapSaleEndpoints(this WebApplication app)
        {
            app.MapPost("/v1/sales", async (SaleViewModel sale, ISaleService _service,
                ISaleItemService _saleItemservice,
                IMonthlyProfitReportService _monthlyProfitReportService, HttpContext http) =>
            {
                //var userId = http.User.FindFirst("sub")?.Value;
                //if (userId == null) return Results.Unauthorized();

                //sale.UserId = Guid.Parse(userId);
                var res = await _service.CreateAsync(sale);

                foreach (var item in sale.SaleItems)
                {
                    item.UserId = sale.UserId;
                    item.SaleId = sale.Id;
                    await _saleItemservice.CreateAsync(item);
                }
                var existentMonthlyProfitReport = await _monthlyProfitReportService.GetMonthlyProfitReportByMonth(sale.Date.Month, sale.UserId);

                if (existentMonthlyProfitReport != null)
                {
                    existentMonthlyProfitReport.TotalProfit += sale.TotalValue;
                    await _monthlyProfitReportService.UpdateAsync(existentMonthlyProfitReport);
                }
                else
                {

                    await _monthlyProfitReportService.UpdateAsync(new MonthlyProfitReportViewModel
                    {
                        Month = sale.Date.Month,
                        UserId = sale.UserId,
                        TotalProfit = sale.TotalValue,
                    });
                }

                return res.Success ? Results.Created($"/v1/sales/{res.Model.Id}", sale) : Results.BadRequest(res);
            });

            app.MapGet("/v1/sales", async (ISaleService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                var sales = await _service.GetAllAsync(Guid.Parse(userId));
                return Results.Ok(sales);
            });

            app.MapGet("/v1/sales/{id:Guid}", async (Guid id, ISaleService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                var sales = await _service.GetOneAsync(id, Guid.Parse(userId));

                return sales != null ? Results.Ok(sales) : Results.NotFound();
            });

            return app;
        }
        public static WebApplication MapProfitReportEndpoints(this WebApplication app)
        {
            app.MapGet("/v1/profit-reports", async (IMonthlyProfitReportService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                var reports = await _service.GetAllAsync(Guid.Parse(userId));
                return Results.Ok(reports);
            });
            return app;
        }
    }
}
