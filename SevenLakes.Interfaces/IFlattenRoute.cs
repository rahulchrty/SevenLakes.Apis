using SevenLakes.Models;
using System.Collections.Generic;

namespace SevenLakes.Interfaces
{
    public interface IFlattenRoute
    {
        List<FlattenedJsonModel> GetFlattenedRoute(NestedJsonModel routeDetails);
    }
}
