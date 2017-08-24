using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahara3.Web.Models;

namespace Yahara3.Web.Service
{
    interface IYahara3Service
    {
        List<Point> CollectPoints(IList<Newtonsoft.Json.Linq.JToken> list);

        List<Point> OrderPoints(List<Point> givenPoints);

        void FindPath(List<Point> givenPoints, List<Point> pathCovered, Double sum, Point point);

        Double EucledianDistance(Point point1, Point point2);

        void FindAllDistances(List<Point> givenPoints);

        Output GenerateOutput(List<Point> orderedPoints);
    }
}
