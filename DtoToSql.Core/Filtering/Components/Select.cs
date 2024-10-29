namespace DtoToSql.Core.Filtering.Components;

public record Select
{
    public string ColumnName { get; set; }
    public string? Alias { get; set; }

    public Select(string columnName, string? alias)
    {
        ColumnName = columnName;
        Alias = alias;
    }

    public override string ToString()
    {
        return string.IsNullOrEmpty(Alias) ? ColumnName : $"{ColumnName} AS {Alias}";
    }
}