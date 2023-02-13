using BookStore.Data;
using BookStore.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(@"Server=LAPTOP-H4AKO82V\SQLEXPRESS;Database=BookStoreFinal;Integrated Security=True;"));
builder.Services.AddScoped<BookRepository, BookRepository>();
builder.Services.AddScoped<LanguageRepository, LanguageRepository>();
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
if (app.Environment.IsDevelopment())
{
    app.MapGet("/Rahul", () => app.Environment.EnvironmentName);
}
//app.MapGet("/", () =>"Hello Rahul");


app.Run();
