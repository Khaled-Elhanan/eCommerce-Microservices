using ProductsMicroService.Core;
using ProductsMicroService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Register layers
builder.Services.AddInfrastructure();
builder.Services.AddCore();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
