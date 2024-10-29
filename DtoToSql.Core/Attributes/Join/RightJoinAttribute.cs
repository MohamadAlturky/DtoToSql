namespace DtoToSql.Core.Attributes.Join;

[AttributeUsage(AttributeTargets.Property)]
public class RightJoinAttribute : JoinAttribute
{
    public RightJoinAttribute(string leftTable,
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