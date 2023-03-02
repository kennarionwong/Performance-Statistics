using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceStatistics.DomainModel;
using PerformanceStatistics.EF;

namespace PerformanceStatistics
{
    public class PerformanceStatisticsRepository
    {
        private PerformanceStatisticsContext dbContext { get; set; } = new PerformanceStatisticsContext();

        public int SaveChanges()
        {
            var entities = dbContext.ChangeTracker
                .Entries().Where(e => e.Entity is BaseEntity && 
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var e = entity.Entity as BaseEntity;
                e.LastModified = DateTime.Now;
            }

            return dbContext.SaveChanges();
        }

        public ObjectValue FindObject(string key)
        {
            var objects = dbContext.ObjectValues.Where(i => i.KeyValue == key);
            var count = objects.Count();

            if (count == 1)
                return objects.Single();
            else if (count == 0)
                return null;
            else
                throw new InvalidOperationException("More than 1 object is found. Please check database.");
        }

        public bool LogEvent(string key, string name, string value)
        {
            var obj = FindObject(key) ?? new ObjectValue() { Name = name, KeyValue = key };
            
            if (obj.Id == 0)
                dbContext.ObjectValues.Add(obj);

            var stats = new Log() { 
                ObjectValue = obj, 
                Value = value.ToUpper().Trim() == "UP", 
                ValueStamp = DateTime.Now 
            };
            dbContext.Logs.Add(stats);
            
            return dbContext.SaveChanges() > 0;
        }

        public bool LogEvent(string key, string name, string value, string timestamp)
        {
            var obj = FindObject(key) ?? new ObjectValue() { Name = name, KeyValue = key };

            if (obj.Id == 0)
                dbContext.ObjectValues.Add(obj);

            var stats = new Log() { 
                ObjectValue = obj, 
                Value = value.ToUpper().Trim() == "UP", 
                ValueStamp = Convert.ToDateTime(timestamp) 
            };
            dbContext.Logs.Add(stats);

            return dbContext.SaveChanges() > 0;
        }

        public bool LogEvent(string key, string name, string value, string timestamp, string message)
        {
            var obj = FindObject(key) ?? new ObjectValue() { Name = name, KeyValue = key };

            if (obj.Id == 0)
                dbContext.ObjectValues.Add(obj);

            var stats = new Log() { 
                ObjectValue = obj, 
                Value = value.ToUpper().Trim() == "UP", 
                ValueStamp = Convert.ToDateTime(timestamp),
                Message = message
            };
            dbContext.Logs.Add(stats);

            return dbContext.SaveChanges() > 0;
        }
    }
}
