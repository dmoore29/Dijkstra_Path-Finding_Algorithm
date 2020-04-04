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

        public ActionResult Index()
        {
            Location[,] g = new Location[10,20];

            for (int i = 0; i < 10; i++)
            {
                int cId = i % 3;
                Console.WriteLine("DIV CLASS: " + i % 3);
                for (int j = 0; j < 20; j++)
                {
                    g[i, j] = new Location { Id = 0, XLoc = i, YLoc = j };
                }
            }

            Grid model = new Grid {action = 0, cId = 0, grid = g};

            return View(model);
        }

        public ActionResult setPath(int x, int y)
        {
            Console.WriteLine("Set path, X: " + x + " Y: " + y);
            Location[,] g = new Location[10, 20];

            for (int i = 0; i < 10; i++)
            {
                int cId = i % 3;
                Console.WriteLine("DIV CLASS: " + i % 3);
                for (int j = 0; j < 20; j++)
                {
                    g[i, j] = new Location { Id = 0, XLoc = i, YLoc = j };
                }
            }

            Grid model = new Grid { action = 0, cId = 0, grid = g };

            model.grid[x, y].Id = 2;

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