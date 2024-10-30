using DtoToSql.QueryBuilder.Abstractions;

namespace DtoToSql.QueryBuilder.Sources;

public class View : DatabaseObject
{
    public View(string name) : base(name)
    {
    }

    public override string GetQuery() => $"SELECT * FROM {Name}";
}