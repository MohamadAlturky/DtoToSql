using System.Reflection;
using DtoToSql.Core.Attributes.Filtering.Order;
using DtoToSql.Core.Attributes.Filtering.Where;
using DtoToSql.Core.Attributes.Meta;
using DtoToSql.Core.Contracts;
using DtoToSql.Core.Filtering.Components;
using DtoToSql.Core.Filtering.Enums;
using DtoToSql.Core.Filtering.Query;
using DtoToSql.Core.Filtering.Source;

namespace DtoToSql.SqlServer.Filtering.Builder;

public static class QueryBuilder
{
    public static SqlQuery BuildQuery<TFilter, TEntity>()
    where TEntity : IDto
    where TFilter : IFilter<TEntity>
    {
        var query = new SqlQuery();

        // Retrieve DataScript
        _handleDataSourceAnnotations<TEntity>(query);


        // Retrieve SELECT clause
        foreach (var prop in typeof(TEntity).GetProperties())
        {
            _handleSelectAnnotations(prop, query);
        }

        // Add WHERE clause based on filter properties
        foreach (var prop in typeof(TFilter).GetProperties())
        {
            _handleWhereAnnotations(prop, query);
        }


        // Add ORDER BY clause based on entity attributes
        foreach (var prop in typeof(TEntity).GetProperties())
        {
            _handleOrderByAnnotations(prop, query);
        }

        return query;
    }

    private static void _handleDataSourceAnnotations<TEntity>(SqlQuery query)
    {
        var fromSqlAttribute = typeof(TEntity).GetCustomAttribute<FromSqlAttribute>();
        if (fromSqlAttribute is not null)
        {
            query.DataScript = new Sql(fromSqlAttribute.Script);
        }

        var tableNameAttribute = typeof(TEntity).GetCustomAttribute<TableNameAttribute>();
        if (tableNameAttribute is not null)
        {
            query.DataScript = new Table(tableNameAttribute.Name);
        }
    }

    private static void _handleOrderByAnnotations(PropertyInfo prop, SqlQuery query)
    {
        if (prop.GetCustomAttribute<OrderByAscendingAttribute>() != null)
        {
            query.OrderByList.Add(new OrderBy(prop.Name, ascending: true));
        }
        else if (prop.GetCustomAttribute<OrderByDescendingAttribute>() != null)
        {
            query.OrderByList.Add(new OrderBy(prop.Name, ascending: false));
        }
    }

    private static void _handleSelectAnnotations(PropertyInfo prop, SqlQuery query)
    {
        var columnAttr = prop.GetCustomAttribute<ColumnAttribute>();
        if (columnAttr is null)
        {
            return;
        }

        if (string.IsNullOrEmpty(columnAttr.Name))
        {
            query.SelectList.Add(new Select(prop.Name, prop.Name));
        }
        else
        {
            query.SelectList.Add(new Select(columnAttr.Name, prop.Name));
        }
    }
    private static void _handleWhereAnnotations(PropertyInfo property, SqlQuery query)
    {
        // Define a dictionary to map attribute types to their corresponding WhereOperation
        var attributeMap = new Dictionary<Type, WhereOperation>
        {
            { typeof(GreaterThanOrEqualAttribute), WhereOperation.GreaterThanOrEqual },
            { typeof(LessThanOrEqualAttribute), WhereOperation.LessThanOrEqual },
            { typeof(EqualsAttribute), WhereOperation.Equals },
            { typeof(NotEqualsAttribute), WhereOperation.NotEquals },
            { typeof(GreaterThanAttribute), WhereOperation.GreaterThan },
            { typeof(LessThanAttribute), WhereOperation.LessThan },
            { typeof(LikeAttribute), WhereOperation.Like }
        };

        // Iterate over each attribute type and apply the corresponding WhereOperation if the attribute exists
        foreach (var keyValuePair in attributeMap)
        {
            var attribute = property.GetCustomAttribute(keyValuePair.Key);
            if (attribute is null) continue;

            // Assuming each attribute has a 'Column' property, use reflection to access it
            var columnProperty = keyValuePair.Key.GetProperty("Column");
            var columnName = columnProperty?.GetValue(attribute)?.ToString();

            if (!string.IsNullOrEmpty(columnName))
            {
                query.WhereSet.Add(new Where(
                    columnName,
                    property,
                    keyValuePair.Value
                ));
            }
        }
    }


    // private static void _handleWhereAnnotations(PropertyInfo prop, SqlQuery query)
    // {
    //     // Check for GreaterOrEqualAttribute
    //     var greaterOrEqualAttribute = prop.GetCustomAttribute<GreaterThanOrEqualAttribute>();
    //     if (greaterOrEqualAttribute is not null)
    //     {
    //         query.WhereSet.Add(new Where(
    //             greaterOrEqualAttribute.Column,
    //             prop.Name,
    //             WhereOperation.GreaterThanOrEqual));
    //     }
    //
    //     // Check for LessOrEqualAttribute
    //     var lessOrEqualAttribute = prop.GetCustomAttribute<LessThanOrEqualAttribute>();
    //     if (lessOrEqualAttribute is not null)
    //     {
    //         query.WhereSet.Add(new Where(
    //             lessOrEqualAttribute.Column,
    //             prop.Name,
    //             WhereOperation.LessThanOrEqual));
    //     }
    //
    //     // Check for EqualsAttribute
    //     var equalsAttribute = prop.GetCustomAttribute<EqualsAttribute>();
    //     if (equalsAttribute is not null)
    //     {
    //         query.WhereSet.Add(new Where(
    //             equalsAttribute.Column,
    //             prop.Name,
    //             WhereOperation.Equals));
    //     }
    //
    //     // Check for NotEqualsAttribute
    //     var notEqualsAttribute = prop.GetCustomAttribute<NotEqualsAttribute>();
    //     if (notEqualsAttribute is not null)
    //     {
    //         query.WhereSet.Add(new Where(
    //             notEqualsAttribute.Column,
    //             prop.Name,
    //             WhereOperation.NotEquals));
    //     }
    //
    //     // Check for GreaterThanAttribute
    //     var greaterThanAttribute = prop.GetCustomAttribute<GreaterThanAttribute>();
    //     if (greaterThanAttribute is not null)
    //     {
    //         query.WhereSet.Add(new Where(
    //             greaterThanAttribute.Column,
    //             prop.Name,
    //             WhereOperation.GreaterThan));
    //     }
    //
    //     // Check for LessThanAttribute
    //     var lessThanAttribute = prop.GetCustomAttribute<LessThanAttribute>();
    //     if (lessThanAttribute is not null)
    //     {
    //         query.WhereSet.Add(new Where(
    //             lessThanAttribute.Column,
    //             prop.Name,
    //             WhereOperation.LessThan));
    //     }
    //
    //     // Check for LikeAttribute (assuming it's for partial matches)
    //     var likeAttribute = prop.GetCustomAttribute<LikeAttribute>();
    //     if (likeAttribute is not null)
    //     {
    //         query.WhereSet.Add(new Where(
    //             likeAttribute.Column,
    //             prop.Name,
    //             WhereOperation.Like));
    //     }
    // }
}