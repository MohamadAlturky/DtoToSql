namespace DtoToSql.Core.Attributes.Filtering.Where;

public class WhereAttribute : Attribute
{
    public WhereAttribute(string column)
    {
        Column = column;
    }

    public string Column { get; }
}