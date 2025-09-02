using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using NorthwindDataStorage.Models;

// OData namespace
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindContext") ?? throw new InvalidOperationException("Connection string 'MyWebAppContext' not found.")));

builder.Services.AddControllers()
    .AddOData(options =>
    {
        var odataBuilder = new ODataConventionModelBuilder();
        //odataBuilder.EntitySet<Customer>("Customers");
        //odataBuilder.EntitySet<Order>("Orders");
        //odataBuilder.EntitySet<Product>("Products");
        options.Select().Filter().Expand().OrderBy().Count().SetMaxTop(100)
               .AddRouteComponents("odata", odataBuilder.GetEdmModel());
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
