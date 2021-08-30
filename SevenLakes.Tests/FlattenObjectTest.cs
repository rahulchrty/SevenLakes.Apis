using Microsoft.VisualStudio.TestTools.UnitTesting;
using SevenLakes.Business;
using SevenLakes.Interfaces;
using SevenLakes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLakes.Tests
{
    [TestClass]
    public class FlattenObjectTest
    {
        private IFlattenObject _flattenObject;
        [TestInitialize]
        public void Setup()
        {
            _flattenObject = new FlattenObject();
        }

        [TestMethod]
        public void Given_A_Route_With_OneStop_And_One_Object()
        {
            //Given:
            string routeName = "Route 1";
            List<ObjectModel> objects = new List<ObjectModel>();
            objects.Add(new ObjectModel
            {
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            StopModel stop = new StopModel {
                StopName = "Stop 1",
                Objects = objects
            };

            //When: I call GetFlattenedObjects
            var result = _flattenObject.GetFlattenedObjects(routeName, stop);

            //Then: I get list with 1 object return
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void Given_A_Route_With_OneStop_And_One_Object_Then_Get_RouteName_As_Route_1()
        {
            //Given:
            string routeName = "Route 1";
            List<ObjectModel> objects = new List<ObjectModel>();
            objects.Add(new ObjectModel
            {
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            StopModel stop = new StopModel
            {
                StopName = "Stop 1",
                Objects = objects
            };

            //When: I call GetFlattenedObjects
            var result = _flattenObject.GetFlattenedObjects(routeName, stop);

            //Then: I get RouteName As "Route 1"
            Assert.AreEqual("Route 1", result[0].RouteName);
        }

        [TestMethod]
        public void Given_A_Route_With_OneStop_And_One_Object_Then_Get_StopName_As_Stop_1()
        {
            //Given:
            string routeName = "Route 1";
            List<ObjectModel> objects = new List<ObjectModel>();
            objects.Add(new ObjectModel
            {
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            StopModel stop = new StopModel
            {
                StopName = "Stop 1",
                Objects = objects
            };

            //When: I call GetFlattenedObjects
            var result = _flattenObject.GetFlattenedObjects(routeName, stop);

            //Then: I get StopName As "Stop 1"
            Assert.AreEqual("Stop 1", result[0].StopName);
        }

        [TestMethod]
        public void Given_A_Route_With_OneStop_And_One_Object_Then_Get_ObjectType_As_tank()
        {
            //Given:
            string routeName = "Route 1";
            List<ObjectModel> objects = new List<ObjectModel>();
            objects.Add(new ObjectModel
            {
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            StopModel stop = new StopModel
            {
                StopName = "Stop 1",
                Objects = objects
            };

            //When: I call GetFlattenedObjects
            var result = _flattenObject.GetFlattenedObjects(routeName, stop);

            //Then: I get ObjectType As "tank"
            Assert.AreEqual("tank", result[0].ObjectType);
        }

        [TestMethod]
        public void Given_A_Route_With_OneStop_And_One_Object_Then_Get_ObjectName_As_MT_ACE_UNIT()
        {
            //Given:
            string routeName = "Route 1";
            List<ObjectModel> objects = new List<ObjectModel>();
            objects.Add(new ObjectModel
            {
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            StopModel stop = new StopModel
            {
                StopName = "Stop 1",
                Objects = objects
            };

            //When: I call GetFlattenedObjects
            var result = _flattenObject.GetFlattenedObjects(routeName, stop);

            //Then: I get ObjectName As "MT ACE UNIT 3H WATER TANK"
            Assert.AreEqual("MT ACE UNIT 3H WATER TANK", result[0].ObjectName);
        }

        [TestMethod]
        public void Given_A_Route_With_OneStop_And_Two_Object()
        {
            //Given:
            string routeName = "Route 1";
            List<ObjectModel> objects = new List<ObjectModel>();
            objects.Add(new ObjectModel
            {
                ObjectType = "tank",
                ObjectName = "MT ACE UNIT 3H WATER TANK"
            });
            objects.Add(new ObjectModel
            {
                ObjectType = "meter",
                ObjectName = "MT ACE UNIT 3H WATER METER"
            });
            StopModel stop = new StopModel
            {
                StopName = "Stop 1",
                Objects = objects
            };

            //When: I call GetFlattenedObjects
            var result = _flattenObject.GetFlattenedObjects(routeName, stop);

            //Then: I get list with 2 objects in return
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void Given_A_Route_With_OneStop_And_NO_Object()
        {
            //Given:
            string routeName = "Route 1";
            List<ObjectModel> objects = new List<ObjectModel>();
            StopModel stop = new StopModel
            {
                StopName = "Stop 1",
                Objects = objects
            };

            //When: I call GetFlattenedObjects
            var result = _flattenObject.GetFlattenedObjects(routeName, stop);

            //Then: I get ObjectType and ObjectName as empty
            Assert.AreEqual(string.Empty, result[0].ObjectType);
            Assert.AreEqual(string.Empty, result[0].ObjectName);
        }
    }
}
