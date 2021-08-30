using SevenLakes.Interfaces;
using SevenLakes.Models;
using System.Collections.Generic;

namespace SevenLakes.Business
{
    public class FlattenJsonContent : IFlattenJsonContent
    {
        private IFlattenRoute _flattenRoute;
        public FlattenJsonContent(IFlattenRoute flattenRoute)
        {
            _flattenRoute = flattenRoute;
        }
        public IList<FlattenedJsonModel> GetFlattenedJson(List<NestedJsonModel> payload)
        {
            List<FlattenedJsonModel> flattenedJson = new List<FlattenedJsonModel>();
            foreach (var eachRoute in payload)
            {
                List<FlattenedJsonModel> flattenRoute = _flattenRoute.GetFlattenedRoute(eachRoute);
                flattenedJson.AddRange(flattenRoute);
            }
            return flattenedJson;
        }
    }
}
