using System.Data;
using DtoToSql.Core.Models;

namespace DtoToSql.Core.Contracts;


public interface IDbWriter<in TTable> 
    where TTable : ITable 
{
    Task<DbResult<TKey>> AddAsync<TKey>(TTable entity, IDbConnection connection);    
    Task<DbResult> UpdateAsync(TTable entity, IDbConnection connection);    
    Task<DbResult> DeleteAsync(TTable entity, IDbConnection connection);    
}