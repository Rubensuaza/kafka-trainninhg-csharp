using io.quind.trainning.kafka.config;
using io.quind.trainning.kafka.repository.config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region log config
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
#endregion

#region dependency injection config
DependencyInjectionConf.DependencyInjectionConfServices(builder.Services);
#endregion

#region databaseconfig
var connectionStrring = builder.Configuration.GetConnectionString("PostgresqlConnection");
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(connectionStrring);
});
#endregion

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
