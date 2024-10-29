namespace DtoToSql.Core.Attributes.Join;

[AttributeUsage(AttributeTargets.Property)]
public class InnerJoinAttribute : JoinAttribute
{
    public InnerJoinAttribute(string leftTable,
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