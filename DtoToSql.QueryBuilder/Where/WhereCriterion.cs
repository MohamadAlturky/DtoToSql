using System.Reflection;
using DtoToSql.QueryBuilder.Abstractions;

namespace DtoToSql.QueryBuilder.Where;

public class WhereCriterion
{
    private readonly Column _column;
    private readonly IWhereOperationStrategy _operationStrategy;
    private readonly PropertyInfo _propertyInfo;

    public WhereCriterion(Column column, IWhereOperationStrategy operationStrategy, PropertyInfo propertyInfo)
    {
        _column = column;
        _operationStrategy = operationStrategy;
        _propertyInfo = propertyInfo;
    }

    public override string ToString()
    {
        return _operationStrategy.ApplyOperation(_column, _propertyInfo.Name);
    }
}