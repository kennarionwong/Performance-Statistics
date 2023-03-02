using Microsoft.Win32.SafeHandles;
using PerformanceStatistics.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceStatistics.EF
{
    internal class PerformanceStatisticsContext : DbContext
    {
#if DEBUG
        public PerformanceStatisticsContext() : base("PerformanceStatistics-Debug") { }
#else
        public PerformanceStatisticsContext() : base("PerformanceStatistics") { }
#endif

        public DbSet<DomainModel.ObjectValue> ObjectValues { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().HasRequired(o => o.ObjectValue)
                .WithMany(s => s.Logs).HasForeignKey(s => s.ObjectID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
