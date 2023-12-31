using Blog.Models;
using Data.Models;
using Blog.Services;
using Blog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IReadService, ReadService>();
builder.Services.AddScoped<IMapperService, MapperService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Post}/{action=Index}/{id?}");

app.Use(async (context, next) =>
{
    string? path = context.Request.Path.Value;
    if (path == "/sayHello")
    {
        await context.Response.WriteAsync("hello");
    }
    else
    {
        await next.Invoke();
    }
});

app.Run();