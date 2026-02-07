using FamilyTree.BlazorApp.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();
builder.Services.AddScoped(sp => new HttpClient());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

// Serve the generated SVG file at /family-tree-svg
app.MapGet("/family-tree-svg", async (HttpContext context) =>
{
    var svgPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "family-tree-svg.svg");
    if (File.Exists(svgPath))
    {
        context.Response.ContentType = "image/svg+xml";
        await context.Response.SendFileAsync(svgPath);
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("SVG file not found. Please generate it first from the home page.");
    }
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
