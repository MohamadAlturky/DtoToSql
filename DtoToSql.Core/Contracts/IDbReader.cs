using System.Data;
using DtoToSql.Core.Models;

namespace DtoToSql.Core.Contracts;

public interface IDbReader<in TFilter, TEntity>
    where TEntity : IDto
    where TFilter : IFilter<TEntity>
{
    Task<DbResult<FilterResponse<TEntity>>> ExecuteAsync(TFilter filter,
        IDbConnection connection);
}