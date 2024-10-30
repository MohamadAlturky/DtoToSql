using DtoToSql.QueryBuilder.Abstractions;

namespace DtoToSql.QueryBuilder.Where;

public interface IWhereOperationStrategy
{
    string ApplyOperation(Column column, string parameterName);
}