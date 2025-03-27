using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Project.API.Mapping;
using Project.Core.Mapping;
using Project.Core.Repositories;
using Project.Core.Service;
using Project.Data;
using Project.Data.Repositories;
using Project.Service;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authorization with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {

            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()

        }

    });
});


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin() 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddScoped<IPharmacistService, PharmacistService>();
builder.Services.AddScoped<IPharmacistRepository, PharmacistRepository>();

builder.Services.AddScoped<IPharmacyService, PharmacyService>();
builder.Services.AddScoped<IPharmacyRepository, PharmacyRepository>();

builder.Services.AddScoped<IStationService, StationService>();
builder.Services.AddScoped<IStationRepository, StationRepository>();

builder.Services.AddScoped<IPatientsQueueService, PatientsQueueService>();
builder.Services.AddScoped<IPatientsQueueRepository, PatientsQueueRepository>();

builder.Services.AddScoped<ISpecialsQueueRepository, SpecialsQueueRepository>();
builder.Services.AddScoped<ISpecialsQueueService, SpecialsQueueService>();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
  @"Server=DESKTOP-SSNMLFD;DataBase=DBPharmacy;TrustServerCertificate=True;Trusted_Connection=True;"));
builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(PostModelMappingProfile));

var jwtKey = builder.Configuration["Jwt:Key"];
if (string.IsNullOrEmpty(jwtKey))
{
    throw new Exception("JWT Key is missing in appsettings.json");
}


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });



var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
