using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedSpark.Thot.Api.Infra.CrossCutting.Settings
{
   
    public class MySettings
    {
        public SwaggerSettings Swagger { get; set; }
    }

    public class SwaggerSettings
    {
        public List<SwaggerInfo> Versions { get; set; }
    }

    public class SwaggerInfo
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
    }
    
}
