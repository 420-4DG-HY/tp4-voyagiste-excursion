global using CarService;
global using CarDTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services de notre système dont on dépend pour les forfaits

//builder.Services.AddSingleton<ICommonDataService, CommonDataServiceProxy>();
//builder.Services.AddSingleton<ICustomerService, CustomerServiceProxy>();
//builder.Services.AddSingleton<IFlightService, FlightServiceProxy>();
//builder.Services.AddSingleton<IHotelService, HotelServiceProxy>();
builder.Services.AddSingleton<ICarService, CarServiceProxy>();
//builder.Services.AddSingleton<ICruiseDataService, CruiseServiceProxy>();
//builder.Services.AddSingleton<IExcursionService, ExcursionServiceProxy>();
//builder.Services.AddSingleton<ITrainService, TrainServiceProxy>();

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
