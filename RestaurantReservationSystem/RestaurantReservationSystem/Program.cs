using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db.Contexts;
using RestaurantReservation.Db.Interfaces.Repositories;
using RestaurantReservation.Db.Interfaces.Services;
using RestaurantReservation.Db.MappingProfiles;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Services;
using RestaurantReservationSystem.configurations;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

// DB.Context
builder.Services.AddDbContext<RestaurantReservationDbContext>(options =>
    options.UseSqlServer("\"Server=(localdb)\\\\MSSQLLocalDB;Database=RestaurantReservationDB;Trusted_Connection=True;\"\r\n"));



// Register Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext
builder.Services.AddDbContext<RestaurantReservationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantReservationDB")));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);

// Register Services
builder.Services.AddRepositoryDependencies();
builder.Services.AddServiceDependencies();


// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretForKey"]!)
            )
        };
    });


var app = builder.Build();
builder.Services.AddAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();