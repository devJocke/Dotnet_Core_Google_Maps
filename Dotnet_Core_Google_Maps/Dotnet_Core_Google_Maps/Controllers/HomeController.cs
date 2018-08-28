﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dotnet_Core_Google_Maps.Models;
using static Dotnet_Core_Google_Maps.DTO.Address;
using Dotnet_Core_Google_Maps.DAO;
using System;

namespace Dotnet_Core_Google_Maps.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {
            GoogleGeoCodeResponse mapData = GoogleMapsFetch.getMapData("https://maps.googleapis.com/maps/api/geocode/json?address=Drottninggatan,%Stockholm%");

            //seperate class for validating data
            try {
                ViewData["Message"] = mapData.results[0].address_components[0].long_name;
            } catch (IndexOutOfRangeException ajdå) {
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
