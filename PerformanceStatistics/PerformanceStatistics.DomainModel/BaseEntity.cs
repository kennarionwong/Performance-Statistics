using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceStatistics
{
    public abstract class BaseEntity
    {
        private static DateTime now = DateTime.Now;
        
        public DateTime CreatedDate { get; private set; } = now;

        public DateTime LastModified { get; set; } = now;
    }
}
