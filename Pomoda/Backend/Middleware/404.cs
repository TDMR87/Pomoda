namespace Pomoda.Backend.Middleware;

public static class NotFoundMiddleware
{
    public static void Use404Middleware(this WebApplication app)
    {
        app.Use(async (httpContext, next) =>
        {
            // Do nothing to the incoming request and call the next middleware.
            await next();

            // Handle the outgoing response. If the response is 404, serve our main page.
            if (httpContext.Response.StatusCode == 404)
            {
                httpContext.Request.Path = "/";
                await next();
            }
        });
    }
}

