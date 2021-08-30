using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SevenLakes.Business;
using SevenLakes.Interfaces;
using SevenLakes.Models;
using System.Collections.Generic;

namespace SevenLakes.Tests
{
    [TestClass]
    public class FlattenJsonContentTest
    {
        private Mock<IFlattenRoute> _mockFlattenRoute;
        private IFlattenJsonContent _flattenJsonContent;
        
        [TestInitialize]
        public void Setup()
        {
            _mockFlattenRoute = new Mock<IFlattenRoute>();
            _flattenJsonContent = new FlattenJsonContent(_mockFlattenRoute.Object);
        }

        [TestMethod]
        public void Given_A_Nested_Json_With_One_Route()
        {
            //Given:
            List<ObjectModel> objects = new List<ObjectModel>();
            objects.Add(new ObjectModel
            {
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            List<StopModel> stops = new List<StopModel>();
            stops.Add(new StopModel
            {
                StopName = "Stop 1",
                Objects = objects
            });
            List<NestedJsonModel> payload = new List<NestedJsonModel>();
            payload.Add(new NestedJsonModel {
                RouteName = "Route 1",
                Stops = stops
            });

            //When: I call GetFlattenedJson
            List<FlattenedJsonModel> flattenedJson = new List<FlattenedJsonModel>();
            flattenedJson.Add(new FlattenedJsonModel { 
                RouteName = "Route 1",
                StopName = "Stop 1",
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            _mockFlattenRoute.Setup(x => x.GetFlattenedRoute(It.IsAny<NestedJsonModel>())).Returns(flattenedJson);
            var resilt = _flattenJsonContent.GetFlattenedJson(payload);

            //Then: Method GetFlattenedRoute executes once
            _mockFlattenRoute.Verify(x => x.GetFlattenedRoute(It.IsAny<NestedJsonModel>()), Times.Once);
        }

        [TestMethod]
        public void Given_A_Nested_Json_With_Two_Routes()
        {
            //Given:
            List<ObjectModel> objects1 = new List<ObjectModel>();
            objects1.Add(new ObjectModel
            {
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            List<StopModel> stops1 = new List<StopModel>();
            stops1.Add(new StopModel
            {
                StopName = "Stop 1",
                Objects = objects1
            });
            List<NestedJsonModel> payload = new List<NestedJsonModel>();
            payload.Add(new NestedJsonModel
            {
                RouteName = "Route 1",
                Stops = stops1
            });

            List<ObjectModel> objects2 = new List<ObjectModel>();
            objects2.Add(new ObjectModel
            {
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 6H WATER TANK"
            });
            List<StopModel> stops2 = new List<StopModel>();
            stops2.Add(new StopModel
            {
                StopName = "Stop 1",
                Objects = objects2
            });
            payload.Add(new NestedJsonModel
            {
                RouteName = "Route 2",
                Stops = stops2
            });

            //When: I call GetFlattenedJson
            List<FlattenedJsonModel> flattenedJson = new List<FlattenedJsonModel>();
            flattenedJson.Add(new FlattenedJsonModel
            {
                RouteName = "Route 1",
                StopName = "Stop 1",
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            flattenedJson.Add(new FlattenedJsonModel
            {
                RouteName = "Route 2",
                StopName = "Stop 1",
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 6H WATER TANK"
            });
            _mockFlattenRoute.Setup(x => x.GetFlattenedRoute(It.IsAny<NestedJsonModel>())).Returns(flattenedJson);
            var resilt = _flattenJsonContent.GetFlattenedJson(payload);

            //Then: Method GetFlattenedRoute executes once
            _mockFlattenRoute.Verify(x => x.GetFlattenedRoute(It.IsAny<NestedJsonModel>()), Times.Exactly(2));
        }
    }
}
