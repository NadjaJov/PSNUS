using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    
    public class Context : DbContext
    {
        public DbSet<AI> AIItems { get; set; }

        public DbSet<AO> AOItems { get; set; }

        public DbSet<DI> DIItems { get; set; }

        public DbSet<DO> DOItems { get; set; }

        public DbSet<Alarm> AlarmItems { get; set; }

        
    }

}
