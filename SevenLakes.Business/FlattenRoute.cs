using SevenLakes.Interfaces;
using SevenLakes.Models;
using System.Collections.Generic;

namespace SevenLakes.Business
{
    public class FlattenRoute : IFlattenRoute
    {
        private IFlattenObject _flattenObject;
        public FlattenRoute(IFlattenObject flattenObject)
        {
            _flattenObject = flattenObject;
        }
        public List<FlattenedJsonModel> GetFlattenedRoute(NestedJsonModel routeDetails)
        {
            List<FlattenedJsonModel> flattenedJson = new List<FlattenedJsonModel>();
            if (routeDetails.Stops.Count > 0)
            {
                foreach (var eachStop in routeDetails.Stops)
                {
                    var a = _flattenObject.GetFlattenedObjects(routeDetails.RouteName, eachStop);
                    flattenedJson.AddRange(a);
                }
            }
            else
            {
                flattenedJson.Add(new FlattenedJsonModel
                {
                    RouteName = routeDetails.RouteName,
                    StopName = string.Empty,
                    ObjectName = string.Empty,
                    ObjectType = string.Empty
                });
            }
            return flattenedJson;
        }
    }
}
