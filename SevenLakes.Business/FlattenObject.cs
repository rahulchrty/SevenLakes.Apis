using SevenLakes.Interfaces;
using SevenLakes.Models;
using System.Collections.Generic;

namespace SevenLakes.Business
{
    public class FlattenObject : IFlattenObject
    {
        public List<FlattenedJsonModel> GetFlattenedObjects(string routeName, StopModel stop)
        {
            List<FlattenedJsonModel> flattenedJson = new List<FlattenedJsonModel>();
            if (stop.Objects.Count > 0)
            {
                foreach (var eachObject in stop.Objects)
                {
                    flattenedJson.Add(new FlattenedJsonModel
                    {
                        RouteName = routeName,
                        StopName = stop.StopName,
                        ObjectName = eachObject.ObjectName,
                        ObjectType = eachObject.ObjectType
                    });
                }
            }
            else
            {
                flattenedJson.Add(new FlattenedJsonModel
                {
                    RouteName = routeName,
                    StopName = stop.StopName,
                    ObjectName = string.Empty,
                    ObjectType = string.Empty
                });
            }
            return flattenedJson;
        }
    }
}
