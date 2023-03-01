namespace Coolicky.ConstructionLogistics.Api.Data;

public record Provider(string Name, string Assembly)
{
    public static Provider Sqlite = new(nameof(Sqlite), typeof(Migrations.Sqlite.Marker).Assembly.GetName().Name!);
    public static Provider Postgres = new(nameof(Postgres), typeof(Migrations.Postgres.Marker).Assembly.GetName().Name!);
    public static Provider SqlServer = new(nameof(SqlServer), typeof(Migrations.SqlServer.Marker).Assembly.GetName().Name!);
}