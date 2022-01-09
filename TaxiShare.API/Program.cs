using Microsoft.EntityFrameworkCore;
using TaxiShare.Data.Context;
using TaxiShare.Hub;
using TaxiShare.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
var serviceCollection = builder.Services;

serviceCollection.AddHub();
serviceCollection.AddInfrastructure(builder.Configuration);

// Add services to the container.

serviceCollection.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
serviceCollection.AddEndpointsApiExplorer();
serviceCollection.AddSwaggerGen();

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
await EnsureDbAsync(app.Services);

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


static async Task EnsureDbAsync(IServiceProvider sp)
{
    await using var db = sp.CreateScope().ServiceProvider.GetRequiredService<DataBase>();
    await db.Database.MigrateAsync();
}
