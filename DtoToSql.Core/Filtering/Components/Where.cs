using System.Reflection;
using DtoToSql.Core.Filtering.Enums;

namespace DtoToSql.Core.Filtering.Components;

public record Where
{
    public Where(string columnName, PropertyInfo propertyInfo, WhereOperation operation)
    {
        ColumnName = columnName;
        PropertyInfo = propertyInfo;
        Operation = operation;
    }

    public string ColumnName { get; set; }
    public PropertyInfo PropertyInfo { get; set; } 
    public WhereOperation Operation { get; set; } 
}