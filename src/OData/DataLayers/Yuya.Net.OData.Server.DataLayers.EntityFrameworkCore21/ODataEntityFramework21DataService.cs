using Microsoft.EntityFrameworkCore;
using System;

namespace Yuya.Net.OData.Server.DataLayers.EntityFrameworkCore21
{
    public class ODataEntityFramework21DataService<T> : IDataService
        where T: DbContext
    {
        private readonly T _dbContext;

        public ODataEntityFramework21DataService(T dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
