using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dotnet_Core_Google_Maps.Models;
using Dotnet_Core_Google_Maps.DAO;
using Microsoft.AspNetCore.Http;
using System;
using static Dotnet_Core_Google_Maps.DTO.MapSmallData;

namespace Dotnet_Core_Google_Maps.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string search) {
            GoogleMapsFetch googleMapsFetch = new GoogleMapsFetch();

            MapFewDetails mapData = googleMapsFetch.getMapData("https://maps.googleapis.com/maps/api/geocode/json?address=" + search);

            try {
                if (mapData != null) {
                    //foreach (address_component addressComponent in mapData.results[0].address_components) {
                    //    //ViewData["Message"] += addressComponent.types[0] + " : " + addressComponent.long_name + "<br />";
                    //    ViewData["Message"] = "This is a test." + "<br />" + "Does it work?" ;
                    // } 

                    // seperate class for validating data

                    //ViewData["Message"] = "https://maps.googleapis.com/maps/api/geocode/json?address=" + search;
                    ViewData["Lat"] = mapData.results[0].geometry.location.lat;
                    ViewData["Long"] = mapData.results[0].geometry.location.lng;
                    return View(mapData.results[0].address_components);


                } else {
                    ViewData["Message"] = "Empty data.";
                }
            } catch (IndexOutOfRangeException outofrange) {
                //Log in some cool way
                ViewData["Message"] = "Empty data.";

            }
            return View();
        }


        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
