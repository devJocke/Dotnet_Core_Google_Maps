using Dotnet_Core_Google_Maps.DTO;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using static Dotnet_Core_Google_Maps.DTO.MapSmallData;

namespace Dotnet_Core_Google_Maps.DAO {

    public class GoogleMapsFetchFactory {

        public MapFewDetails getMapData(string url) {

            try {

                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream data = response.GetResponseStream();
                StreamReader reader = new StreamReader(data);
                string result = reader.ReadToEnd();
                response.Close();

                if (result != null | result.Length != 0) {
                    return JsonConvert.DeserializeObject<MapFewDetails>(result);
                }
            } catch (Exception e) {
            }
            return null;
        }
    }

    //TODO Interface for factory
    //TODO Add Map to the factory
}