namespace Pomoda.Shared.Utils;

public static class Razor
{
    public static RazorComponentResult Component<TComponent>(object? model = null) where TComponent : IComponent
    {
        return model is null
            ? new RazorComponentResult<TComponent>()
            : new RazorComponentResult<TComponent>(new { Model = model });
    }
}
