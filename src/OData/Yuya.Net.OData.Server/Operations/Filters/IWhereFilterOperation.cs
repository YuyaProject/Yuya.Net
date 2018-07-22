namespace Yuya.Net.OData.Server.Operations.Filters
{
    public interface IWhereFilterOperation : IFilterOperation
    {
        string WhereString { get; }
    }
}