namespace DtoToSql.QueryBuilder.Abstractions;

public abstract class DatabaseObject
{
    public string Name { get; set; }
    protected DatabaseObject(string name) => Name = name;

    public abstract string GetQuery();
}