using System;
namespace MvcMovie.Models
{
    public class Location
    {
        //public int XLoc { get; set; }
        //public int YLoc { get; set; }
        //public int Id { get; set; }

        private int XLoc;
        private int YLoc;
        private int Id;

        public void setX(int x)
        {
            XLoc = x;
        }

        public void setY(int y)
        {
            YLoc = y;
        }

        public void setId(int id)
        {
            Id = id;
        }

        public int getX()
        {
            return XLoc;
        }

        public int getY()
        {
            return YLoc;
        }

        public int getId()
        {
            return Id;
        }
    }

}
