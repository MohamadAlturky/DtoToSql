namespace DtoToSql.QueryBuilder.Abstractions;

public class OrderBy
{
    public Column Column { get; set; }
    public bool IsAscending { get; set; }

    public OrderBy(Column column, bool isAscending = true)
    {
        Column = column;
        IsAscending = isAscending;
    }

    public override string ToString()
    {
        return $"{Column.Name} {(IsAscending ? "ASC" : "DESC")}";
    }
}