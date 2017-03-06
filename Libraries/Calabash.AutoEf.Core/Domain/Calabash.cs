using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calabash.AutoEf.Core.Domain
{
    public class Calabash : BaseEntity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int Sex { get; set; }

        public string Grilfriend { get; set; }
    }
}
