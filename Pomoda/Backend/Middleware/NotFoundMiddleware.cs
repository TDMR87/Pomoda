namespace Pomoda.Backend.Middleware;

public static class NotFoundMiddleware
{
    public static void UseNotFoundMiddleware(this WebApplication app)
    {
        app.Use(async (httpContext, next) =>
        {
            // Ignore the incoming request, just call the next middleware in the pipeline
            await next(); 

            // Handle the outgoing response. If status code is 404, redirect to the main page
            if (httpContext.Response.StatusCode == 404)
            {
                httpContext.Response.Redirect("/");
            }
        });
    }
}

