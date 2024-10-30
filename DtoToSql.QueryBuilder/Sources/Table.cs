using DtoToSql.QueryBuilder.Abstractions;

namespace DtoToSql.QueryBuilder.Sources;

public class Table : DatabaseObject
{
    public Table(string name) : base(name)
    {
    }

    public override string GetQuery() => $"SELECT * FROM {Name}";
}