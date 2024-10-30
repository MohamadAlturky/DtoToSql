namespace DtoToSql.QueryBuilder.Abstractions;

public class Column
{
    public string Name { get; set; }
    public string Alias { get; set; }

    public Column(string name, string alias = null)
    {
        Name = name;
        Alias = alias;
    }

    public override string ToString()
    {
        return Alias != null ? $"{Name} AS {Alias}" : Name;
    }
}