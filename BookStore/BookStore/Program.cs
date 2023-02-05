var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
if (app.Environment.IsDevelopment())
{
    app.MapGet("/Rahul", () => app.Environment.EnvironmentName);
}
//app.MapGet("/", () =>"Hello Rahul");


app.Run();
