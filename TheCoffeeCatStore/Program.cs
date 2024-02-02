using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatRepository.Repository;
using TheCoffeeCatService.IServices;
using TheCoffeeCatService.Services;
using TheCoffeeCatStore.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ApplicationMapper));

builder.Services.AddScoped<ICatRepo, CatRepo>();
builder.Services.AddScoped<ICatServices, CatServices>();
builder.Services.AddScoped<ICoffeeShopRepo, CoffeeShopRepo>();
builder.Services.AddScoped<ICoffeeShopServices, CoffeeShopServices>();
builder.Services.AddScoped<IStaffRepo, StaffRepo>();
builder.Services.AddScoped<IStaffServices, StaffServices>();
builder.Services.AddScoped<IDrinkRepo, DrinkRepo>();
builder.Services.AddScoped<IDrinkServices, DrinkServices>();
builder.Services.AddScoped(_=> new BlobServiceClient(builder.Configuration.GetConnectionString("AzureBlobStorage")));




builder.Services.AddMvc()
                .AddNewtonsoftJson(
                        options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; }
        );
//builder.Services.AddAutoMapper



var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
