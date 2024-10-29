namespace DtoToSql.Core.Filtering.Components;

public record OrderBy
{
    public OrderBy(string columnName, bool ascending = true)
    {
        ColumnName = columnName;
        Ascending = ascending;
    }

    public string ColumnName { get; set; }
    public bool Ascending { get; set; }
}