using QF_ALMACEN_API.Almacen.Data;
using QF_ALMACEN_API.Almacen.Service;
using QF_ALMACEN_API.General.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//repositorios

builder.Services.AddScoped<AlmacenRepository>();

//servivios

builder.Services.AddScoped<AlmacenService>();



//Connection

builder.Services.AddScoped<ServicesConnection>();

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
