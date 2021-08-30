using SevenLakes.Models;
using System.Collections.Generic;

namespace SevenLakes.Interfaces
{
    public interface IFlattenJsonContent
    {
        IList<FlattenedJsonModel> GetFlattenedJson(List<NestedJsonModel> payload);
    }
}
