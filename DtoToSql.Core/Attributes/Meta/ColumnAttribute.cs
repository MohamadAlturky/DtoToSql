namespace DtoToSql.Core.Attributes.Meta;

[AttributeUsage(AttributeTargets.Property)]
public class ColumnAttribute : Attribute
{
    public ColumnAttribute()
    {
    }

    public ColumnAttribute(string name)
    {
        Name = name;
    }

    public string? Name { get; set; }
}