namespace DtoToSql.Core.Filtering.Source;

public class Sql(string value) : IDataScript
{
    public string Value { get; set; } = value;
}