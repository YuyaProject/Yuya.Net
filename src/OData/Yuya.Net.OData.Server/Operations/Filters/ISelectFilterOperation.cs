namespace Yuya.Net.OData.Server.Operations.Filters
{
    public interface ISelectFilterOperation : IFilterOperation
    {
        string SelectString { get; }
    }
}