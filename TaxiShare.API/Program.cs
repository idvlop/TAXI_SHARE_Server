using Microsoft.EntityFrameworkCore;
using TaxiShare.Infrastructure.Context;
using TaxiShare.Hub;
using TaxiShare.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaxiShare.API;
using MediatR;
using TaxiShare.Application.Requests.Admin.Queries;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var serviceCollection = builder.Services;
#region SERVICES SETUP

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
            ValidateIssuerSigningKey = true
        };
    });

serviceCollection.AddDbContext<TaxiShareDbContext>(options => 
    options.UseNpgsql(builder.Configuration["ConnectionStrings:Default"],
        b => b.MigrationsAssembly("TaxiShare.Infrastructure")));

serviceCollection.AddAuthorization();
serviceCollection.AddSwaggerGen(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
serviceCollection.AddRouting(options => options.LowercaseUrls = true);
serviceCollection.AddMediatR(typeof(Program), typeof(GetAllTripsAdminQueryHandler));
#endregion

var app = builder.Build();
#region MIDDLEWARE SETUP
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
#endregion

app.Run();


//static async Task EnsureDbAsync(IServiceProvider sp)
//{
//    await using var db = sp.CreateScope().ServiceProvider.GetRequiredService<TaxiShareDbContext>();
//    await db.Database.MigrateAsync();
//}
