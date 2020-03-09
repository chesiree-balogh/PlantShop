using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantShop.Models;

namespace PlantShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        public DatabaseContext db { get; set; } = new DatabaseContext();

        //post/add new location
        [HttpPost]
        public Location CreateALocation(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return location;
        }


        //get all locations
        [HttpGet]
        public List<Location> GetAllLocations()
        {
            var locations = db.Locations.OrderBy(m => m.Address);
            return locations.ToList();
        }
    }
}