namespace DtoToSql.QueryBuilder.Where;

public static class WhereOperationFactory
{
    public static IWhereOperationStrategy GetStrategy(WhereOperation operation)
    {
        return operation switch
        {
            WhereOperation.Equals => new EqualsOperation(),
            WhereOperation.NotEquals => new NotEqualsOperation(),
            WhereOperation.GreaterThan => new GreaterThanOperation(),
            WhereOperation.LessThan => new LessThanOperation(),
            WhereOperation.GreaterThanOrEqual => new GreaterThanOrEqualOperation(),
            WhereOperation.LessThanOrEqual => new LessThanOrEqualOperation(),
            WhereOperation.Like => new LikeOperation(),
            _ => throw new NotImplementedException()
        };
    }
}