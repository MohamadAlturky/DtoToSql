namespace DtoToSql.Core.Attributes.Filtering.Where;

[AttributeUsage(AttributeTargets.Property)]
public class LikeAttribute : WhereAttribute
{
    public LikeAttribute(string column) : base(column)
    {
    }
}