using DtoToSql.QueryBuilder.Abstractions;

namespace DtoToSql.QueryBuilder.Sources;

public abstract class Join : DatabaseObject
{
    protected DatabaseObject Left { get; }
    protected DatabaseObject Right { get; }
    protected Column LeftColumn { get; }
    protected Column RightColumn { get; }

    protected Join(DatabaseObject left, DatabaseObject right, Column leftColumn, Column rightColumn, string name)
        : base(name)
    {
        Left = left;
        Right = right;
        LeftColumn = leftColumn;
        RightColumn = rightColumn;
    }
}