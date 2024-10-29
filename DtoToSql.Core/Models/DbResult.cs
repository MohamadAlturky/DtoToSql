namespace DtoToSql.Core.Models;

public class DbResult
{
    public bool Success { get; set; }
    public Exception? Exception { get; set; }

}
public class DbResult<T> : DbResult
{
    public T? Data { get; set; }
}