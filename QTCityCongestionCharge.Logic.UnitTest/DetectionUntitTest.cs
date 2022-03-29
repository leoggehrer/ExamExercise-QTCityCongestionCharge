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

        [TestInitialize]
        public void TestInitialize()
        {
            Task.Run(async () => await DeleteControllerEntities()).Wait();
        }

        [TestMethod]
        public async Task Create_ValidDetectionWithFossileCar_ExpectedAccept()
        {
            var carUnitTest = new CarUnitTest();
            var ownerUnitTest = new OwnerUnitTest();

            await carUnitTest.DeleteControllerEntities();
            await ownerUnitTest.DeleteControllerEntities();

            var owner = ownerUnitTest.CreateValidOwner();
            var car = carUnitTest.CreateValidFossileCar();

            Assert.IsNotNull(owner);
            Assert.IsNotNull(car);
            car.Owner = owner;

            var entity = CreateValidDetection(DateTime.Now, MovementType.Entering, new List<Car>() { car });

            Assert.IsNotNull(entity);
            await Create_OfEntity_AndCheck(entity);
        }
    }
}
