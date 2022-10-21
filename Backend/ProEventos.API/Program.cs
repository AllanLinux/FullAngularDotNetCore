using Microsoft.EntityFrameworkCore;
using ProEventos.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Get connection from appsettings
var connectionString = builder.Configuration.GetConnectionString("Default");
// Add DbContext
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlite(connectionString)
);
// Add services to the container.
builder.Services.AddControllers();
// Add Cors
builder.Services.AddCors();
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
// Configuration Cors
app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

app.MapControllers();

app.Run();
