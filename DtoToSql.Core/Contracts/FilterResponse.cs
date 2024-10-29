namespace DtoToSql.Core.Contracts;

public class FilterResponse<TEntity>
    where TEntity : IDto
{
    public List<TEntity> Data { get; set; }
    public long Total { get; set; }
}