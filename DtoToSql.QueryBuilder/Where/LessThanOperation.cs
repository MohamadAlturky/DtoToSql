using DtoToSql.QueryBuilder.Abstractions;

namespace DtoToSql.QueryBuilder.Where;

public class LessThanOperation : IWhereOperationStrategy
{
    public string ApplyOperation(Column column,string parameterName) => $"{column.Alias} < {parameterName}";
}