
using Microsoft.EntityFrameworkCore;
using Practica_2.DATA.AutoMapper;
using Practica_2.DATA.DataContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

// Add services to the container.
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();
app.MapControllers();

app.Run();
