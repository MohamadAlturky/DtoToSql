using DtoToSql.QueryBuilder.Abstractions;

namespace DtoToSql.QueryBuilder.Sources;

public class InnerJoin : Join
{
    public InnerJoin(DatabaseObject left, DatabaseObject right, Column leftColumn, Column rightColumn)
        : base(left, right, leftColumn, rightColumn, "INNER JOIN")
    {
    }

    public override string GetQuery()
    {
        return $"{Left.GetQuery()} INNER JOIN {Right.Name} ON {LeftColumn.Name} = {RightColumn.Name}";
    }
}