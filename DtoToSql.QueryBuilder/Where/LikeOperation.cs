using DtoToSql.QueryBuilder.Abstractions;

namespace DtoToSql.QueryBuilder.Where;

public class LikeOperation : IWhereOperationStrategy
{
    public string ApplyOperation(Column column,string parameterName) => $"{column.Alias} LIKE '%{parameterName}%'";
}