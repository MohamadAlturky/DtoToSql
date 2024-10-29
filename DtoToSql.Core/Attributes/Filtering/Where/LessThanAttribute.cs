namespace DtoToSql.Core.Attributes.Filtering.Where;

[AttributeUsage(AttributeTargets.Property)]
public class LessThanAttribute : WhereAttribute
{
    public LessThanAttribute(string column) : base(column)
    {
    }
}