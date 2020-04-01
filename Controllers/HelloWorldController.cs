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
        public ActionResult index()
        {
           Grid model = new Grid();
            return View(model);
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