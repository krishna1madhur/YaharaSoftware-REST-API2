using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yahara3.Web.Models
{
    public class Point
    {
        private int PointNumber;
        private double X { set; get; }
        private double Y { set; get; }

        public Point(int pointNumber, double X, double Y)
        {
            this.PointNumber = pointNumber;
            this.X = X;
            this.Y = Y;
        }
        public void SetPointNumber(int PointNumber) { this.PointNumber = PointNumber; }
        public int GetPointNumber() { return PointNumber; }
        public void SetX(double X) { this.X = X; }
        public void SetY(double Y) { this.Y = Y; }
        public double GetX() { return X; }
        public double GetY() { return Y; }
        
    }
}