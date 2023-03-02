using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PerformanceStatistics.DomainModel
{
    public class ObjectValue : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string KeyValue { get; set; }

        // Navigation Properties
        public virtual ICollection<Log> Logs { get; set; }
    }
}
