using Newtonsoft.Json;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatRepository.Repository;
using TheCoffeeCatService.IServices;
using TheCoffeeCatService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICatRepo, CatRepo>();
builder.Services.AddScoped<ICatServices, CatServices>();
builder.Services.AddScoped<ICoffeeShopRepo, CoffeeShopRepo>(); 
builder.Services.AddScoped<ICoffeeShopServices, CoffeeShopServices>();




builder.Services.AddMvc()
                .AddNewtonsoftJson(
                        options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; }
        );
//builder.Services.AddAutoMapper


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
