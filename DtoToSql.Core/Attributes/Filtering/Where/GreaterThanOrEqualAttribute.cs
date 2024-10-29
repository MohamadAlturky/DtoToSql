namespace DtoToSql.Core.Attributes.Filtering.Where;

[AttributeUsage(AttributeTargets.Property)]
public class GreaterThanOrEqualAttribute : WhereAttribute
{
    public GreaterThanOrEqualAttribute(string column) : base(column)
    {
    }
}