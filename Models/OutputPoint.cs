using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yahara3.Web.Models
{
    public class OutputPoint
    {
        public int PointNumber { set; get; }
        public List<double> PointValues { set; get; }

        public OutputPoint(int PointNumber, List<double> PointValues) {
            this.PointNumber = PointNumber;
            this.PointValues = new List<double>(PointValues);
        }

        public int GetPointNumber() { return PointNumber; }
        public List<double> GetPointValues() { return PointValues; }
        public void SetPointNumber(int pointNumber) {
            this.PointNumber = pointNumber;
        }
        public void SetPointValues(List<double> pointValues) {
            this.PointValues = pointValues;
        }
    }
}