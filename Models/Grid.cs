using System;
namespace MvcMovie.Models
{
    public class Grid
    {
        private Location[,] grid;
        private int cId = 0;


        public Grid()
        {
            grid = new Location[10,20];

            for (int i = 0; i < 10; i++)
            {
                cId = i % 3;
                Console.WriteLine("DIV CLASS: " + i % 3);
                for (int j = 0; j < 20; j++)
                {
                    grid[i, j] = new Location();
                    grid[i,j].setX(i);
                    grid[i,j].setY(j);
                    grid[i,j].setId(cId);
                }
            }
        }

        public Location[,] getGrid()
        {
            return grid;
        }

        public int getId(int i, int j)
        {
            return grid[i,j].getId();
        }
    }
}
