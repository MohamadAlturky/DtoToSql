namespace DtoToSql.Core.Attributes.Filtering.Where;

[AttributeUsage(AttributeTargets.Property)]
public class LessThanOrEqualAttribute : WhereAttribute
{
    public LessThanOrEqualAttribute(string column) : base(column)
    {
    }
}