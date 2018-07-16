using System.Threading.Tasks;

namespace Yuya.Net.OData.Server
{
    /// <summary>
    /// OData Service Interface
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Runs the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task RunAsync();
    }
}
