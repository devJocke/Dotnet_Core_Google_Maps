using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace Dotnet_Core_Google_Maps.DTO {

    public class MapSmallData {

        public class MapFewDetails {
            public results[] results { get; set; }
        }

        public class results {
            public geometry geometry { get; set; }
            public address_component[] address_components { get; set; }
        }

        public class address_component {
            public string long_name { get; set; }
            public string[] types { get; set; }
        }

        public class geometry { 
            public location location { get; set; }
        }

        public class location {
            public string lat { get; set; }
            public string lng { get; set; }
        }
    }
}