using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Calabash.AutoEf.Core.Caching
{
    public interface  IRedisConnectionWrapper:IDisposable
    {
        IDatabase Database(int? db = null);

        IServer Server(EndPoint endPoint);

        EndPoint[] GetEndPoints();

        void FlushDb(int? db = null);
    }
}
