using Microsoft.EntityFrameworkCore;
using TaxiShare.Data.Context;
using TaxiShare.Hub;
using TaxiShare.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.OAuth;
using TaxiShare.API;

var builder = WebApplication.CreateBuilder(args);
var serviceCollection = builder.Services;
#region SERVICES

//TaxiShare_Server's projects injections:
serviceCollection.AddHub();
serviceCollection.AddInfrastructure(builder.Configuration);

//Services:
serviceCollection.AddControllers();
serviceCollection.AddEndpointsApiExplorer();

serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // Подключение аутентификации с помощью jwt-токенов
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    }); 
serviceCollection.AddAuthorization();
serviceCollection.AddSwaggerGen(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#endregion


//const string ConnectionString = "Default";

//IConfiguration Configuration { get; }

//void ConfigureServices(IServiceCollection services)
//{
//    var connection = Configuration.GetConnectionString(ConnectionString);
//    services.AddDbContext<Db>(options =>
//                options.UseNpgsql(connection,
//                    b => b.MigrationsAssembly("HRVRAcademy.WebUI")));
//}

var app = builder.Build();
//await EnsureDbAsync(app.Services);

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


//static async Task EnsureDbAsync(IServiceProvider sp)
//{
//    await using var db = sp.CreateScope().ServiceProvider.GetRequiredService<TaxiShareDbContext>();
//    await db.Database.MigrateAsync();
//}
