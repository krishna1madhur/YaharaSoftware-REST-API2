using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yahara3.Web.Models;
using Yahara3.Web.Service;

namespace Yahara3.Web.Controllers
{
    public class PointsController : ApiController
    {
        public Output Post([FromBody]JObject jObject)
        {
            JObject pointsArray = JObject.Parse(jObject.ToString());
            IList<JToken> results = pointsArray["points"].Children().ToList();

            IYahara3Service service = new Yahara3ServiceImplementation();

            List<Point> givenPoints = service.CollectPoints(results);

            List<Point> orderedPoints = service.OrderPoints(givenPoints);

            Output outputObject = service.GenerateOutput(orderedPoints);

            return outputObject;
        }
    }
}
