namespace DtoToSql.Core.Attributes.Filtering.Where;

[AttributeUsage(AttributeTargets.Property)]
public class GreaterThanAttribute : WhereAttribute
{
    public GreaterThanAttribute(string column) : base(column)
    {
    }
}