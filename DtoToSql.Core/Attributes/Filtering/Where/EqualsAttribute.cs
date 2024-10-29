namespace DtoToSql.Core.Attributes.Filtering.Where;

[AttributeUsage(AttributeTargets.Property)]
public class EqualsAttribute : WhereAttribute
{
    public EqualsAttribute(string column) : base(column)
    {
    }
}