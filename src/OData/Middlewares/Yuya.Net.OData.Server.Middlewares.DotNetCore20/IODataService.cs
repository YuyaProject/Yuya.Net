using System.Threading.Tasks;

namespace Yuya.Net.OData.Server.DotNetCore20
{
    internal interface IODataService
    {
        Task RunAsync();
    }
}