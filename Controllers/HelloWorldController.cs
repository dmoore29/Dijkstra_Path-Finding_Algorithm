using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{

    public class HelloWorldController : Controller
    {
        private readonly MvcMovieContext _context;

        public HelloWorldController(MvcMovieContext context)
        {
            _context = context;
        }

        //public async Task<IActionResult> Index()
        public ActionResult Index()
        {
            List<Location> testL = new List<Location>();
            foreach (var l in _context.Location)
            {
                testL.Add(l);
            }

            LocationGroup lg = new LocationGroup { locations = testL };
            Grid model = new Grid { action = 0, cId = 0, grid = lg };

            return View(model);
        }

        public ActionResult setPath(int x, int y)
        {
            Console.WriteLine("Set path, X: " + x + " Y: " + y);

            List<Location> testL = new List<Location>();

            int act = 0;

            foreach (var l in _context.Location)
            {
                testL.Add(l);
            }

            var a = _context.G;
            foreach (var ac in a)
            {
                if(x == 100 && y == 100)
                {
                    ac.action = 1;
                } else if (x == 101 && y == 101)
                {
                    ac.action = 2;
                } else if (x == 102 && y == 102)
                {
                    ac.action = 3;
                }
                else if (x == 103 && y == 103)
                {
                    ac.action = 0;
                }
                _context.SaveChanges();

                act = ac.action;
            }

            LocationGroup lg = new LocationGroup { locations = testL };

            

            Grid model = new Grid { action = 0, cId = 0, grid = lg };

            List<Location> updatedTestL = new List<Location>();

            Location rip = new Location { XLoc = 0, YLoc = 0, myD = 0 };

            foreach (var l in model.grid.locations)
            {
                if(l.XLoc == x && l.YLoc == y)
                {
                    rip = new Location { XLoc = l.XLoc, YLoc = l.YLoc, myD = act};
                    l.myD = act;
                    _context.SaveChanges();
                    updatedTestL.Add(rip);
                }
                else
                {
                    updatedTestL.Add(l);
                }
            }

            model.grid.locations = updatedTestL;
            return View("Index", model);
        }

        //public void testing()
        //{
        //    Console.WriteLine("Testing... ");
        //}

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}