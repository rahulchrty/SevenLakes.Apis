using Microsoft.VisualStudio.TestTools.UnitTesting;
using SevenLakes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using SevenLakes.Business;
using SevenLakes.Models;

namespace SevenLakes.Tests
{
    [TestClass]
    public class FlattenRouteTest
    {
        private Mock<IFlattenObject> _mockFlattenObject;
        private IFlattenRoute _flattenRoute;

       [TestInitialize]
        public void Setup()
        {
            _mockFlattenObject = new Mock<IFlattenObject>();
            _flattenRoute = new FlattenRoute(_mockFlattenObject.Object);
        }

        [TestMethod]
        public void Given_A_Round_Rediels_One_Route_One_Stop_And_One_Object()
        {
            //Given:
            List<ObjectModel> objects = new List<ObjectModel>();
            objects.Add(new ObjectModel { 
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            List<StopModel> stops = new List<StopModel>();
            stops.Add(new StopModel { 
                StopName = "Stop 1",
                Objects = objects
            });
            NestedJsonModel routeDetails = new NestedJsonModel { 
                RouteName = "Route 1",
                Stops = stops
            };

            //When: I call GetFlattenedRoute
            List<FlattenedJsonModel> flattenedJsonModels = new List<FlattenedJsonModel>();
            flattenedJsonModels.Add(new FlattenedJsonModel { 
                RouteName = "Route 1",
                StopName = "Stop 1",
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            _mockFlattenObject.Setup(x => x.GetFlattenedObjects(It.IsAny<string>(), It.IsAny<StopModel>()))
                .Returns(flattenedJsonModels);
            var result = _flattenRoute.GetFlattenedRoute(routeDetails);

            //Then: Method GetFlattenedObjects executes once
            _mockFlattenObject.Verify(x => x.GetFlattenedObjects(It.IsAny<string>(), It.IsAny<StopModel>()), Times.Once);
        }

        [TestMethod]
        public void Given_A_Round_Rediels_One_Route_Two_Stop_And_One_Object()
        {
            //Given:
            List<ObjectModel> objectsForStop1 = new List<ObjectModel>();
            objectsForStop1.Add(new ObjectModel
            {
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            List<ObjectModel> objectsForStop2 = new List<ObjectModel>();
            objectsForStop2.Add(new ObjectModel
            {
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 5H WATER TANK"
            });
            List<StopModel> stops = new List<StopModel>();
            stops.Add(new StopModel
            {
                StopName = "Stop 1",
                Objects = objectsForStop1
            });
            stops.Add(new StopModel
            {
                StopName = "Stop 2",
                Objects = objectsForStop2
            });
            NestedJsonModel routeDetails = new NestedJsonModel
            {
                RouteName = "Route 1",
                Stops = stops
            };

            //When: I call GetFlattenedRoute
            List<FlattenedJsonModel> flattenedJsonModels = new List<FlattenedJsonModel>();
            flattenedJsonModels.Add(new FlattenedJsonModel
            {
                RouteName = "Route 1",
                StopName = "Stop 1",
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            flattenedJsonModels.Add(new FlattenedJsonModel
            {
                RouteName = "Route 1",
                StopName = "Stop 2",
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 5H WATER TANK"
            });
            _mockFlattenObject.Setup(x => x.GetFlattenedObjects(It.IsAny<string>(), It.IsAny<StopModel>()))
                .Returns(flattenedJsonModels);
            var result = _flattenRoute.GetFlattenedRoute(routeDetails);

            //Then: Method GetFlattenedObjects executes twice
            _mockFlattenObject.Verify(x => x.GetFlattenedObjects(It.IsAny<string>(), It.IsAny<StopModel>()), Times.Exactly(2));
        }

        [TestMethod]
        public void Given_A_Round_Rediels_One_Route_And_NO_Stops()
        {
            //Given:
            NestedJsonModel routeDetails = new NestedJsonModel
            {
                RouteName = "Route 1",
                Stops = new List<StopModel>()
            };

            //When: I call GetFlattenedRoute
            List<FlattenedJsonModel> flattenedJsonModels = new List<FlattenedJsonModel>();
            flattenedJsonModels.Add(new FlattenedJsonModel
            {
                RouteName = "Route 1",
                StopName = string.Empty,
                ObjectType = string.Empty,
                ObjectName = string.Empty
            });
            var result = _flattenRoute.GetFlattenedRoute(routeDetails);

            //Then: Method GetFlattenedObjects never executes
            _mockFlattenObject.Verify(x => x.GetFlattenedObjects(It.IsAny<string>(), It.IsAny<StopModel>()), Times.Never);
        }

        [TestMethod]
        public void Given_A_Round_Rediels_One_Route_And_NO_Stops_Then_Get_Stop_As_Empty()
        {
            //Given:
            NestedJsonModel routeDetails = new NestedJsonModel
            {
                RouteName = "Route 1",
                Stops = new List<StopModel>()
            };

            //When: I call GetFlattenedRoute
            List<FlattenedJsonModel> flattenedJsonModels = new List<FlattenedJsonModel>();
            flattenedJsonModels.Add(new FlattenedJsonModel
            {
                RouteName = "Route 1",
                StopName = string.Empty,
                ObjectType = string.Empty,
                ObjectName = string.Empty
            });
            var result = _flattenRoute.GetFlattenedRoute(routeDetails);

            //Then: I get StopName, ObjectType and ObjectName as empty
            Assert.AreEqual(String.Empty, result[0].StopName);
            Assert.AreEqual(String.Empty, result[0].ObjectType);
            Assert.AreEqual(String.Empty, result[0].ObjectName);
        }
    }
}
