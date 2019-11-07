using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.Helpers
{
    public class ClaudinarySettings
    {
        /// <summary>Gets or sets the name of the cloud.</summary>
        /// <value>The name of the cloud.</value>
        public string CloudName { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
    }
}
