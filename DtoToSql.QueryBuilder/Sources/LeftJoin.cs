using DtoToSql.QueryBuilder.Abstractions;

namespace DtoToSql.QueryBuilder.Sources;

public class LeftJoin : Join
{
    public LeftJoin(DatabaseObject left, DatabaseObject right, Column leftColumn, Column rightColumn)
        : base(left, right, leftColumn, rightColumn, "LEFT JOIN")
    {
    }

    public override string GetQuery()
    {
        return $"{Left.GetQuery()} LEFT JOIN {Right.Name} ON {LeftColumn.Name} = {RightColumn.Name}";
    }
}