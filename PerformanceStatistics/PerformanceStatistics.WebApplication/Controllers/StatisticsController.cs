using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PerformanceStatistics;

namespace PerformanceStatistics.WebApplication.Controllers
{
    public class StatisticsController : ApiController
    {
        private PerformanceStatisticsRepository repository { get; set; } = new PerformanceStatisticsRepository();

        [HttpGet]
        public string Index() => "Ok";

        [HttpGet]
        public string Index(string id) => $"value: { id }";

        [HttpPost]
        public bool LogEvent(
            [FromUri] string key, 
            [FromUri] string name, 
            [FromUri] string value) => repository.LogEvent(key, name, value);
        
        [HttpPost]
        public bool LogEvent(
            [FromUri] string key, 
            [FromUri] string name, 
            [FromUri] string value, 
            [FromUri] string timestamp) => repository.LogEvent(key, name, value, timestamp);
        
        [HttpPost]
        public bool LogEvent(
            [FromUri] string key, 
            [FromUri] string name, 
            [FromUri] string value, 
            [FromUri] string timestamp, 
            [FromUri] string message) => repository.LogEvent(key, name, value, timestamp, message);

    }
}