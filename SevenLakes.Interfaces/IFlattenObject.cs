using SevenLakes.Models;
using System.Collections.Generic;

namespace SevenLakes.Interfaces
{
    public interface IFlattenObject
    {
        List<FlattenedJsonModel> GetFlattenedObjects(string routeName, StopModel stop);
    }
}
