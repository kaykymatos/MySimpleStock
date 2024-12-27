using MyGoodStock.Api.Models.ViewModel;
using MyGoodStock.Api.Services;

namespace MyGoodStock.Api.Endpoints
{
    public static class ApiEndpoints
    {
        public static WebApplication MapProductEndpoints(this WebApplication app)
        {
            app.MapPost("/products", async (ProductViewModel product, IProductService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                product.UserId = Guid.Parse(userId);

                var res = await _service.CreateAsync(product);

                return res.Success ? Results.Created($"/products/{product.Id}", product) : Results.BadRequest(res);
            });

            app.MapGet("/products", async (IProductService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                var products = await _service.GetAllAsync(Guid.Parse(userId));
                return Results.Ok(products);
            });

            app.MapPut("/products", async (ProductViewModel product, IProductService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                product.UserId = Guid.Parse(userId);

                var res = await _service.UpdateAsync(product);

                return res.Success ? Results.NoContent() : Results.BadRequest(res);
            });

            app.MapDelete("/products/{id}", async (Guid id, IProductService _service, HttpContext http) =>
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
            app.MapPost("/stock-movements", async (StockMovementViewModel movement, IStockMovementService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                movement.UserId = Guid.Parse(userId);
                var res = await _service.CreateAsync(movement);

                return res.Success ? Results.Created($"/stock-movements/{movement.Id}", movement) : Results.BadRequest(res);
            });

            app.MapGet("/stock-movements", async (IStockMovementService _service, HttpContext http) =>
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
            app.MapPost("/sales", async (SaleViewModel sale, ISaleService _service, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                sale.UserId = Guid.Parse(userId);
                var res = await _service.CreateAsync(sale);

                return res.Success ? Results.Created($"/sales/{sale.Id}", sale) : Results.BadRequest(res);
            });

            app.MapGet("/sales", async (ISaleService _service, HttpContext http) =>
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
            app.MapGet("/profit-reports", async (IMonthlyProfitReportService _sales, HttpContext http) =>
            {
                var userId = http.User.FindFirst("sub")?.Value;
                if (userId == null) return Results.Unauthorized();

                var reports = await _sales.GetAllAsync(Guid.Parse(userId));
                return Results.Ok(reports);
            });
            return app;
        }
    }
}
