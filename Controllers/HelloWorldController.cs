using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using System;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        //Location[,] grid = new Location[10, 20];

        public IActionResult Index()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    //grid[i, j].setX(i);
                    //grid[i, j].setY(j);
                    //grid[i, j].setId(0);
                }
            }
            //ViewData["Grid"] = grid;
            return View();
        }

        // GET: Movies/Edit/5
        public void Sel(int i, int j, int id)
        {
            if(id == 0)
            {
                //grid[i, j].setId(1);
                Console.WriteLine("IT WORKED " + id);
            }
        }
                            //<a asp-action="sel" asp-route-id="@i"></a>


        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}