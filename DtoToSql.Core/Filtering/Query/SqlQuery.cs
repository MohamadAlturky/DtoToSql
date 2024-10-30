using DtoToSql.Core.Filtering.Components;
using DtoToSql.Core.Filtering.Source;

namespace DtoToSql.Core.Filtering.Query;

public record SqlQuery
{
    public IDataScript? DataScript { get; set; }

    public List<Column> ColumnList { get; set; } = [];

    public HashSet<Where> WhereSet { get; set; } = [];

    public List<OrderBy> OrderByList { get; set; } = [];
}