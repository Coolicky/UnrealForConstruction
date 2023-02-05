using API.Data;
using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;

builder.Services.AddDbContext<UnrealContext>(options =>
{
    var provider = config.GetValue("Provider", Provider.Sqlite.Name);
    if (provider == Provider.Sqlite.Name)
        options.UseSqlite(
            config.GetConnectionString(Provider.Sqlite.Name)!,
            x => x.MigrationsAssembly(Provider.Sqlite.Assembly));
    if (provider == Provider.Postgres.Name)
        options.UseSqlite(
            config.GetConnectionString(Provider.Postgres.Name)!,
            x => x.MigrationsAssembly(Provider.Postgres.Assembly));
    if (provider == Provider.SqlServer.Name)
        options.UseSqlite(
            config.GetConnectionString(Provider.SqlServer.Name)!,
            x => x.MigrationsAssembly(Provider.SqlServer.Assembly));
});

// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UnrealContext>();
    await UnrealContext.InitializeAsync(db);
}

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