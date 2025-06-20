using QF_ALMACEN_API.Almacen.Distribucion;
using QF_ALMACEN_API.Almacen.Factura;
using QF_ALMACEN_API.Almacen.PreIngreso.Data;
using QF_ALMACEN_API.Almacen.PreIngreso.Service;
using QF_ALMACEN_API.Almacen.Productos;
using QF_ALMACEN_API.General.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//repositorios

builder.Services.AddScoped<PreIngresoRepository>();
builder.Services.AddScoped<FacturaRepository>();
builder.Services.AddScoped<DistribucionRepository>();
builder.Services.AddScoped<ProductosRepository>();

//servivios

builder.Services.AddScoped<PreIngresoService>();
builder.Services.AddScoped<FacturaService>();
builder.Services.AddScoped<DistribucionService>();
builder.Services.AddScoped<ProductosService>();


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
