
using FoodDeliveryKG.Models;
using Microsoft.EntityFrameworkCore;
    
    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
   
builder.Services.AddDbContext<FoodDeliveryKGContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("foodyprojectdb"))
);
Console.WriteLine();
//services cors
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
