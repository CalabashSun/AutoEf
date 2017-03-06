using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calabash.AutoEf.Data.Mapping
{
    public partial class CalabashMap : EntityTypeConfiguration<Core.Domain.Calabash>
    {
        public CalabashMap()
        {
            this.ToTable("Calabash");
            this.HasKey(u => u.Id);
        }
    }
}
