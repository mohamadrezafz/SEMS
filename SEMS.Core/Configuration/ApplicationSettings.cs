using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Core.Configuration
{
    public class ApplicationSettings
    {
        public string ProjectCode { get; set; }
        public DataBaseSettings DatabaseSettings { get; set; }
        public ExternalService ExternalService { get; set; }
    }

    public class DataBaseSettings
    {
        public string Connection { get; set; }
    }
    public class ExternalService
    {
    }
}
