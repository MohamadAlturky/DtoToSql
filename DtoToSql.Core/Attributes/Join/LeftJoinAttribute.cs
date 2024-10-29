namespace DtoToSql.Core.Attributes.Join;

[AttributeUsage(AttributeTargets.Property)]
public class LeftJoinAttribute : JoinAttribute
{
    public LeftJoinAttribute(string leftTable,
        string rightTable,
        string onLeftTableKey,
        string onRightTableKey)
        : base(leftTable,
            rightTable,
            onLeftTableKey,
            onRightTableKey)
    {
    }
}