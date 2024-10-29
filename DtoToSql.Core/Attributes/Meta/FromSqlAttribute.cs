namespace DtoToSql.Core.Attributes.Meta;

[AttributeUsage(AttributeTargets.Class)]
public class FromSqlAttribute(string script) : Attribute
{
    public string Script { get; } = script;
}