using System;
using System.Collections.Generic;
namespace MvcMovie.Models
{
    public class LocationGroup
    {
        public int Id { set; get; }
        public List<Location> locations { set; get; }

        //public Location()
        //{
        //    XLoc = 0;
        //    YLoc = 0;
        //    Id = 0;
        //}

        //public void setX(int x)
        //{
        //    XLoc = x;
        //}

        //public void setY(int y)
        //{
        //    YLoc = y;
        //}

        //public void setId(int id)
        //{
        //    Id = id;
        //}

        //public int getX()
        //{
        //    return XLoc;
        //}

        //public int getY()
        //{
        //    return YLoc;
        //}

        //public int getId()
        //{
        //    return Id;
        //}
    }

}
