using System.Collections.Generic;

namespace SevenLakes.Models
{
    public class NestedJsonModel
    {
        public string RouteName { get; set; }
        public List<StopModel> Stops { get; set; }
    }
}