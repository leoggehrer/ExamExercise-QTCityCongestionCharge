using Microsoft.VisualStudio.TestTools.UnitTesting;
using QTCityCongestionCharge.Logic.Controllers;
using QTCityCongestionCharge.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTCityCongestionCharge.Logic.UnitTest
{
    [TestClass]
    public class DetectionUntitTest : EntityUnitTest<Entities.Detection>
    {
        private CommonUnitTest CommonUnitTest { get; } = new CommonUnitTest();
        public override GenericController<Detection> CreateController()
        {
            return new DetectionsController();
        }

        public Detection CreateValidDetection(DateTime taken, MovementType movementType, List<Car> cars)
        {
            return new Detection
            {
                Taken = taken,
                PhotoUrl = $"www.detections.at/{++Counter}",
                MovementType = movementType,
                DetectedCars = cars,
            };
        }

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    CommonUnitTest.DeleteAllEntities();
        //}

        [TestMethod]
        public async Task Create_ValidDetectionWithFossileCar_ExpectedAccept()
        {
            var carUnitTest = new CarUnitTest();
            var ownerUnitTest = new OwnerUnitTest();
            var owner = await ownerUnitTest.CreateValidOwnerAndStore();

            Assert.IsNotNull(owner);
            //var car = await carUnitTest.CreateValidFossilCarAndStore(owner.Id);

            //Assert.IsNotNull(car);
            //var entity = CreateValidDetection(DateTime.Now, MovementType.Entering, new List<Car>() { car });
            //await Create_OfEntity_AndCheck(entity);
        }
    }
}
