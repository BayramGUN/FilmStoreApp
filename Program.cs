using System.Reflection;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //Build an "AutoMapper" service configuration 
builder.Services.AddDbContext<FilmsApi.DBO.FilmsDbContext>(options => 
    options.UseInMemoryDatabase(databaseName:"FilmsDB")
);
var app = builder.Build();
using(var scope = app.Services.CreateScope())
{ 
    var services = scope.ServiceProvider;
    FilmsApi.DBO.DataGenerator.Initialize(services);
}


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
