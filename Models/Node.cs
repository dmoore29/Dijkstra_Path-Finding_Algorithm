using System;
namespace MvcMovie.Models
{
    public class Node
    {
        public Boolean wall;
        public int xLoc;
        public int yLoc;
        public int gCost;
        public int hCost;
        public Node parent;
        public int myD;
        public int fCost()
        {
            return gCost + hCost;
        }
    }

}
