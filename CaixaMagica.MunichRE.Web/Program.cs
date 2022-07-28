using CaixaMagica.MunichRE.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string compiledDBConnection = "Data Source="+Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database\\InspirationalQuotes.db"); //Make sure to get local DB to be used anywhere, ignore ConnectionString in appsettings

//builder.Services.AddSqlite<InspirationalQuotesdbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSqlite<InspirationalQuotesdbContext>(compiledDBConnection);

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

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
    pattern: "{controller=Quotes}/{action=Index}/{id?}");

app.Run();
