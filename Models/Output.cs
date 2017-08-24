using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yahara3.Web.Models
{
    public class Output
    {
        public List<OutputPoint> Points { set; get; }
        public Output(List<OutputPoint> points) {
            this.Points = points;
        }
        public Output() { }
        public void SetPoints(List<OutputPoint> points) {
            this.Points = points;
        }
        public List<OutputPoint> GetPoints() { return Points; }
    }
}