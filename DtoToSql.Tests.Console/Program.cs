using DtoToSql.Core.Attributes.Filtering.Order;
using DtoToSql.Core.Attributes.Filtering.Where;
using DtoToSql.Core.Attributes.Meta;
using DtoToSql.Core.Contracts;
using DtoToSql.SqlServer.Filtering.Builder;

var sqlQuery = QueryBuilder.BuildQuery<PersonVwFilter, PersonVw>();
Console.WriteLine(sqlQuery.DataScript.Value);
Console.WriteLine("Where clause");
foreach (var where in sqlQuery.WhereSet)
{
    Console.WriteLine("ColumnName "+where.ColumnName);
    Console.WriteLine("Operation "+where.Operation);
    Console.WriteLine("PropertyInfo.Name "+where.PropertyInfo.Name);
}
Console.WriteLine();

Console.WriteLine("Select clause");
foreach (var select in sqlQuery.ColumnList)
{
    Console.WriteLine("ColumnName "+select.ColumnName);
    Console.WriteLine("Alias "+select.Alias);
}

Console.WriteLine();
Console.WriteLine("OrderBy clause");
foreach (var orderBy in sqlQuery.OrderByList)
{
    Console.WriteLine(orderBy.ColumnName);
    Console.WriteLine(orderBy.Ascending?"Ascending":"Descending");
}

public class PersonVwFilter : IFilter<PersonVw>
{
    [GreaterThanOrEqual("Id")]
    public int? BiggerThanId { get; set; }
}



[FromSql("SELECT * FROM PersonVw")]
[TableName("PersonVw")]
public class PersonVw : IDto
{
    [OrderByDescending]
    [Column("Id")]
    public int BaseId { get; set; }
    
    [OrderByAscending]
    [Column]
    public string Name { get; set; } = string.Empty;
}