using MyGoodStock.Api.Models.ViewModel;
using MyGoodStock.Api.Services;

namespace MyGoodStock.Api.Endpoints
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

            app.MapGet("/v1/products", async (IProductService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                var products = await _service.GetAllAsync(Guid.Parse(userId));
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
        public static WebApplication MapStockMovementEndpoints(this WebApplication app)
        {
            app.MapPost("/v1/stock-movements", async (StockMovementViewModel movement, IStockMovementService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                movement.UserId = Guid.Parse(userId);
                var res = await _service.CreateAsync(movement);

                return res.Success ? Results.Created($"/v1/stock-movements/{res.Model.Id}", movement) : Results.BadRequest(res);
            });

            app.MapGet("/v1/stock-movements", async (IStockMovementService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                var movements = await _service.GetAllAsync(Guid.Parse(userId));
                return Results.Ok(movements);
            });

            return app;
        }
        public static WebApplication MapSaleEndpoints(this WebApplication app)
        {
            app.MapPost("/v1/sales", async (SaleViewModel sale, ISaleService _service, HttpContext http) =>
            {
                //var userId = http.User.FindFirst("sub")?.Value;
                //if (userId == null) return Results.Unauthorized();

                //sale.UserId = Guid.Parse(userId);
                var res = await _service.CreateAsync(sale);

                return res.Success ? Results.Created($"/v1/sales/{res.Model.Id}", sale) : Results.BadRequest(res);
            });

            app.MapGet("/v1/sales", async (ISaleService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                var sales = await _service.GetAllAsync(Guid.Parse(userId));
                return Results.Ok(sales);
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
