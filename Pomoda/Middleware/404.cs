namespace Pomoda.Middleware;

public static class NotFoundMiddleware
{
    public static void Use404Middleware(this WebApplication app)
    {
        app.Use(async (httpContext, next) =>
        {
            // Call next middleware to continue processing the incoming request.
            await next();

            // Process the outgoing response. If the response is 404, serve our front-end main page.
            if (httpContext.Response.StatusCode == 404 && !Path.HasExtension(httpContext.Request.Path.Value))
            {
                httpContext.Request.Path = "/index.html";
                await next();
            }
        });
    }
}

