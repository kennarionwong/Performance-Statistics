using System;
using System.ComponentModel.DataAnnotations;

namespace PerformanceStatistics.DomainModel
{
    public class Log : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ObjectID { get; set; }

        [Required]
        public bool Value { get; set; }
        
        [Required]
        public DateTime ValueStamp { get; set; } = DateTime.Now;

        public string Message { get; set; } = "";

        // Navigation Properties
        public virtual ObjectValue ObjectValue { get; set; }

    }
}
