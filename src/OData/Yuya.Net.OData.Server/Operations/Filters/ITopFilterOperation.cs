namespace Yuya.Net.OData.Server.Operations.Filters
{
    public interface ITopFilterOperation : IFilterOperation
    {
        int Top { get; }
    }
}