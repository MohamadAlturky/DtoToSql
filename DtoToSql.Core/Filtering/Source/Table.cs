namespace DtoToSql.Core.Filtering.Source;

public class Table(string value) : IDataScript
{
    public string Value { get; set; } = value;
}