using eCommerce.Core;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers();

var app = builder.Build();

// Configure middleware
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();