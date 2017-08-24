using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Yahara3.Web.Models;

namespace Yahara3.Web.Service
{
    public class Yahara3ServiceImplementation : IYahara3Service
    {
        private static double[,] distanceMatrix;
        private static double minSum = Double.MaxValue;
        private static List<Point> finalPath = new List<Point>();

        public List<Point> CollectPoints(IList<JToken> list)
        {
            List<Point> givenPoints = new List<Point>();
            int count = 1;
            int pointNumber = 1;
            foreach (JToken item in list)
            {
                if (item[count.ToString()] == null) {
                    continue;
                }
                IList<JToken> pointObject = item[count.ToString()].Children().ToList();
                Point point = new Point(pointNumber++, (double)pointObject[0], (double)pointObject[1]);
                givenPoints.Add(point);
                count++;
            }
            return givenPoints;
        }

        public List<Point> OrderPoints(List<Point> givenPoints)
        {
            
            List<Point> pathCovered = null;
            int numberOfPoints = givenPoints.Count;

            if (givenPoints == null|| numberOfPoints == 0) return null;
            else if (numberOfPoints == 1) return givenPoints;

            minSum = Double.MaxValue;
            distanceMatrix = new double[numberOfPoints, numberOfPoints];
            FindAllDistances(givenPoints);

            for (int i = 0; i < numberOfPoints; i++) {
                pathCovered = new List<Point>();
                pathCovered.Add(givenPoints[i]);
                FindPath(givenPoints, pathCovered, 0, givenPoints[i]);
            }
            return finalPath;
        }

        public void FindPath(List<Point> givenPoints, List<Point> pathCovered, Double sum, Point lastPoint)
        {
            if (givenPoints.Count == 1)
            {
                if (sum < minSum)
                {
                    minSum = sum;
                    finalPath = new List<Point>(pathCovered);
                    return;
                }
            }
            List<Point> loopOver = new List<Point>(givenPoints);
            loopOver.Remove(lastPoint);
            List<Point> oldPoints = new List<Point>(loopOver);
            foreach (Point point in loopOver.ToList()) {
                List<Point> extendedPath = new List<Point>(pathCovered);
                extendedPath.Add(point);
                double tempSum = sum + distanceMatrix[lastPoint.GetPointNumber()-1, point.GetPointNumber()-1];

                FindPath(oldPoints, extendedPath, tempSum, point);
            }
        }

        public void FindAllDistances(List<Point> givenPoints)
        {
            int numberOfPoints = givenPoints.Count;
            for (int i=0; i<numberOfPoints; i++)
            {
                for(int j=i+1; j<numberOfPoints; j++)
                {
                    double distance = EucledianDistance(givenPoints[i], givenPoints[j]);
                    distanceMatrix[i,j] = distance;
                    distanceMatrix[j,i] = distance;
                }
            }
        }

        public double EucledianDistance(Point point1, Point point2)
        {
            double xValue = Math.Pow((point1.GetX() - point2.GetX()), 2);
            double yValue = Math.Pow((point1.GetY() - point2.GetY()), 2);
            double result = Math.Sqrt(xValue + yValue);
            return result;
        }

        public Output GenerateOutput(List<Point> orderedPoints)
        {
            List<OutputPoint> resultList = new List<OutputPoint>();
            foreach (Point point in orderedPoints)
            {
                List<double> pointValues = new List<double>();
                pointValues.Add(point.GetX());
                pointValues.Add(point.GetY());
                OutputPoint temp = new OutputPoint(point.GetPointNumber(), pointValues);
                resultList.Add(temp);
            }

            return new Output(resultList);
        }
    }
}