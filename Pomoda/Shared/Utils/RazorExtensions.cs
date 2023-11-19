using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Pomoda.Shared.Utils;

public static class Razor
{
    /// <summary>
    /// Returns a razor component of type <TComponent>, 
    /// passing an optional model object to the component as the component parameter.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public static RazorComponentResult Component<TComponent>(object? model = null) where TComponent : IComponent
    {
        return model is null
            ? new RazorComponentResult<TComponent>()
            : new RazorComponentResult<TComponent>(new { Model = model });
    }
}
