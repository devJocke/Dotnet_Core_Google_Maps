using Dotnet_Core_Google_Maps.DTO;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using static Dotnet_Core_Google_Maps.DTO.Address;

namespace Dotnet_Core_Google_Maps.DAO {

    public class GoogleMapsFetch {

        private static WebClient webClient = new WebClient();

        public static GoogleGeoCodeResponse getMapData(string url) {

            //TODO:: BAD URL CHECK
            string result = webClient.DownloadString(url);
            if (result != null | result.Length != 0) {
                return JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(result);
            }
            return null;
        }
    }
}