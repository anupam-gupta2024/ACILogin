using ACILogin.Models;
using ACILogin.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Get our SQL Connection
builder.Services.Configure<DataConnection>(builder.Configuration.GetSection("DataConnection"));
builder.Services.Configure<DataConnection>(builder.Configuration.GetSection("DataConnection2"));

//builder.Services.AddScoped<IBusinessLayer, DataLayer>();
//builder.Services.AddTransient<IBusinessAccess, DataAccess>();

builder.Services.AddTransient<IDataService, DataService>();
//builder.Services.AddTransient<IDefaultConnection, DefaultConnection>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
