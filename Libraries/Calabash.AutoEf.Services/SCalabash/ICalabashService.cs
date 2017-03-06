using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calabash.AutoEf.Services.SCalabash
{
    public interface ICalabashService
    {
        string CalabashName();

        IList<Core.Domain.Calabash> GetAll();
    }
}
