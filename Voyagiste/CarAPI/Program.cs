global using CarBLL;
global using CarDAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Instances de nos BLL et DAL
builder.Services.AddSingleton<ICarDataAccess, CarDataAccess>();
builder.Services.AddSingleton<ICarBusinessLogic, CarBusinessLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();  // Retiré pour ne pas avoir à gérer le certificat Docker

app.UseAuthorization();

app.MapControllers();

app.Run();
