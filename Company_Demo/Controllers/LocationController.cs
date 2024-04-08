using Company_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Company_Demo.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult ShowLoc()
        {
            Location loc = new Location();
            SqlDataReader rdr = loc.GetConnected();
            ViewBag.ShowDetails = rdr;
            return View();
        }
        public IActionResult DeleteLoc(string locndel)
        {
            Location loc = new Location();
            loc.DeleteLocation(locndel);
            return RedirectToAction("ShowLoc");

        }
        [HttpGet]
        public IActionResult UpdateLoc(string locnupd)
        {
            Location loc = new Location();
            ViewBag.rdr=loc.showUpdate(locnupd);
            return View();
        }
        [HttpPost]
        public IActionResult UpdateLoc(string locnid, string locndesc)
        {
            Location loc = new Location();
            loc.updateLocation(locnid, locndesc);
            return RedirectToAction("ShowLoc");
        }
        [HttpGet]
        public IActionResult InsertLocation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertLocation(string locnid,string locndesc)
        {
            Location loc = new Location();
            loc.InsertLocation(locnid,locndesc);

            return RedirectToAction("ShowLoc");
        }


    }
}
