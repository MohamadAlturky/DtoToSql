namespace DtoToSql.Core.Attributes.Join;

[AttributeUsage(AttributeTargets.Property)]
public class JoinAttribute : Attribute
{
    public string LeftTable { get; set; }
    public string RightTable { get; set; }
    public string OnLeftTableKey { get; set; }
    public string OnRightTableKey { get; set; }

    public JoinAttribute(string leftTable, string rightTable,
        string onLeftTableKey, string onRightTableKey)
    {
        LeftTable = leftTable;
        RightTable = rightTable;
        OnLeftTableKey = onLeftTableKey;
        OnRightTableKey = onRightTableKey;
    }
}