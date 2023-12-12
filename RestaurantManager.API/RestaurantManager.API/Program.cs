using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RestaurantManager.API.Configuration;
using RestaurantManager.Business.Definitions;
using RestaurantManager.Business.Implementations;
using RestaurantManager.Database.Context;
using RestaurantManager.Database.UOW;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("RestaurantManagerDatabase");

//Database Layer
builder.Services.AddDbContext<RestaurantManagerDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Business Layer
builder.Services.AddScoped<IAddressBusiness, AddressBusiness>();
builder.Services.AddScoped<IDriverBusiness, DriverBusiness>();
builder.Services.AddScoped<IMenuBusiness, MenuBusiness>();
builder.Services.AddScoped<IOrderBusiness, OrderBusiness>();
builder.Services.AddScoped<IPaymentBusiness, PaymentBusiness>();
builder.Services.AddScoped<IRatingBusiness, RatingBusiness>();
builder.Services.AddScoped<IRestaurantBusiness, RestaurantBusiness>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();

//Automapper for DTOs
builder.Services.AddAutoMapper(typeof(MapperInitializer));

// Add services to the container.

builder.Services.AddControllers();

// Adding Authentication  
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer  
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
