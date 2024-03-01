using System.Text;
using ApplicationServices;
using ApplicationServices.Interfaces;
using Domain;
using DomainServices;
using Infrastructure;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Identity;
using Persistence.Identity.Interfaces;
using Persistence.SqlDataBase;
using Persistence.SqlDataBase.SqlRepository;


var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json")
                          .Build();


builder.Services.AddDbContext<CoffeeBackEndDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("CoffeeConnection")));


builder.Services.AddIdentityCore<ApplicationUser>(opt =>
    {
        opt.Password.RequireNonAlphanumeric = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CoffeeBackEndDbContext>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ReactOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173/", "https://localhost:44357/"
                )
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
        });
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "JwtBearer";
        options.DefaultChallengeScheme = "JwtBearer";
    })
    .AddJwtBearer("JwtBearer", jwtBearerOptions =>
    {
        jwtBearerOptions.SaveToken = true;
        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKeyIsSecret")),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(30)
        };
    });


builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<ICoffeeShopRepository, CoffeeShopRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICoffeeShopServices, CoffeeShopServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddTransient<IUserManagerService, UserManagerService>();
builder.Services.AddScoped<IEmailService, EmailService>();


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
app.UseCors("ReactOrigin");


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<CoffeeBackEndDbContext>();
        await context.Database.MigrateAsync();
        //await SeedData.Initialize(context);
    }
    catch (Exception e)
    {
       var logger = services.GetRequiredService<ILogger<Program>>();
       logger.LogError(e, "An error occurred during migration");
    }
}
app.MapControllers();

app.Run();
