namespace Coolicky.ConstructionLogistics.Api.Data;

public record Provider(string Name, string Assembly)
{
    public static Provider Sqlite = new(nameof(Sqlite), typeof(Sqlite.Marker).Assembly.GetName().Name!);
    public static Provider Postgres = new(nameof(Postgres), typeof(Postgres.Marker).Assembly.GetName().Name!);
    public static Provider SqlServer = new(nameof(SqlServer), typeof(SqlServer.Marker).Assembly.GetName().Name!);
}