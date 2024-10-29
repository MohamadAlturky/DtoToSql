namespace DtoToSql.Core.Attributes.Filtering.Where;

[AttributeUsage(AttributeTargets.Property)]
public class NotEqualsAttribute : WhereAttribute
{
    public NotEqualsAttribute(string column) : base(column)
    {
    }
}