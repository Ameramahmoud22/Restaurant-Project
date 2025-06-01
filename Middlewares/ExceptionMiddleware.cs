
// to catch and handle exceptions (errors) that occur during HTTP requests to your API

namespace RestaurantSystem.API.Middleware
{

    //Purpose: This class is the middleware that catches exceptions during request processing.
    public class ExceptionMiddleware
    {
        //RequestDelegate is a delegate (a type of function pointer) that represents the next step in the middleware pipeline.
        //_next is the next middleware or endpoint to handle the HTTP request after this one.
        private readonly RequestDelegate _next;


        // Uses (DI) to receive the next middleware in the chain and stores it in _next.
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // InvokeAsync is the method that gets called for each HTTP request.
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                //to create a JSON object like { "error": "Menu item not found" }.
                await httpContext.Response.WriteAsync(
                    System.Text.Json.JsonSerializer.Serialize(new { error = ex.Message }));
            }
        }
    }


    //Purpose: This is a helper class to make it easy to register the middleware
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}