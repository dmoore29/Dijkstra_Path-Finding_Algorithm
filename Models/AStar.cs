using System;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class AStar
    {
        public List<Node> nodesList;
        public Node[,] nodesArray;
        public List<Node> open;
        public List<Node> closed;
        public Node start;
        public Node end;

        public AStar(List<Location> locs) //constructor
        {
            nodesList = new List<Node>();
            nodesArray = new Node[10,20];
            open = new List<Node>();
            closed = new List<Node>();
            //converts list of locations to list of nodes and populates start and end
            foreach (var l in locs)
            {
                Node n = new Node { gCost = 0, hCost = 0, xLoc = l.XLoc, yLoc = l.YLoc , wall = false, myD = l.myD};
                if(l.myD == 1)
                {
                    start = n;
                } else if (l.myD == 2)
                {
                    end = n;
                } else if (l.myD == 3)
                {
                    n.wall = true;
                }
                nodesList.Add(n);
                for (int i = 0; i<10; i++)
                {
                    for(int j = 0; j<20; j++)
                    {
                        foreach(var v in nodesList)
                        {
                            if(v.xLoc == i && v.yLoc == j)
                            {
                                nodesArray[i, j] = v;
                            }
                        }
                    }
                }
            }
        }


        public List<Node> tracePath()
        {
            List<Node> path = new List<Node> ();
            Node currentNode = end.parent;

            while (currentNode != start)
            {
                path.Add(currentNode);
                currentNode = currentNode.parent;
            }
            path.Reverse();
            Console.WriteLine("CHECK F");
            return path;
        }

        public List<Node> neighbors(Node n)
        {
            List<Node> neighborsFound = new List<Node>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int x = n.xLoc + i;
                    int y = n.yLoc + j;

                    if(x >= 0 && x < 10 && y >= 0 && y < 20)
                    {
                        neighborsFound.Add(nodesArray[x, y]);
                        Console.WriteLine("NEIGHBOR FOUND FOR NODE X: " + n.xLoc + " Y: " + n.yLoc + "NEIGHBOR IS X: " + x + " Y: " + y);
                    }
                }
            }
            return neighborsFound;
        }

        public int distance(Node a, Node b)
        {
            int xDist = (int)MathF.Abs(a.xLoc - b.xLoc);
            int yDist = (int)MathF.Abs(a.yLoc - b.yLoc);

            if(xDist > yDist)
            {
                return 14 * yDist + 10 * (xDist - yDist);
            }
            return 14 * xDist + 10 * (yDist - xDist);
        }

        public List<Location> findPath()
        {
            open.Add(start); //adds the starting node to open list

            while (open.Count > 0)
            {
                Console.WriteLine("CHECK H");
                Node current = open[0];
                for(int i = 1; i < open.Count; i++)
                {
                    if(open[i].fCost() < current.fCost() || (open[i].fCost() == current.fCost() && open[i].hCost < current.hCost))
                    {
                        current = open[i];
                    }
                }

                open.Remove(current);
                closed.Add(current);

                if(current == end)
                {
                    List<Node> finalPath = tracePath();
                    List<Location> finalLocationPath = new List<Location>();
                    int count = 0;
                    foreach (var o in nodesList)
                    {
                        finalLocationPath.Add(new Location { myD = o.myD, XLoc = o.xLoc, YLoc = o.yLoc });
                        foreach (var f in finalPath)
                        {
                            if (f.xLoc == o.xLoc && f.yLoc == o.yLoc)
                            {
                                finalLocationPath[count].myD = 4;
                                finalLocationPath[count].XLoc = f.xLoc;
                                finalLocationPath[count].YLoc = f.yLoc;
                            }
                        }
                        count++;
                    }
                    Console.WriteLine("CHECK I");
                    return finalLocationPath;
                }

                foreach(Node n in neighbors(current))
                {
                    if(n.wall || closed.Contains(n))
                    {
                        continue;
                    }

                    int newCost = current.gCost + distance(current, n);
                    if(newCost < n.gCost || !open.Contains(n))
                    {
                        Console.WriteLine("CHECK J");
                        n.gCost = newCost;
                        n.hCost = distance(n, end);
                        n.parent = current;

                        if (!open.Contains(n))
                        {
                            open.Add(n);
                        }
                    }

                }
            }
            return new List<Location>();
        }
    }
}
