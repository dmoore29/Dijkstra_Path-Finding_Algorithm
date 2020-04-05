using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.G.Any())
                {
                    return;   // DB has been seeded
                }

                List<Location> locs = new List<Location>();

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("DIV CLASS: " + i % 3);
                    for (int j = 0; j < 20; j++)
                    {
                        locs.Add(new Location { Id = 0, XLoc = i, YLoc = j, myD = 0 });
                    }
                }

                LocationGroup lg = new LocationGroup { locations = locs };

                context.G.AddRange(


                new Grid {
                    action = 0,
                    cId = 0,
                    grid = lg
                }
                );
                context.SaveChanges();
            }
        }
    }
}