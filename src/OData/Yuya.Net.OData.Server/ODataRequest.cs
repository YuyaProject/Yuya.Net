namespace Yuya.Net.OData.Server.DotNetCore20.Services
{
    public class ODataRequest
    {
        public string EntityName { get; set; }

        public string ActionName { get; set; }

        public string Query { get; set; }

        public IService Service { get; set; }

        public IDataService DataService { get; set; }
    }
}