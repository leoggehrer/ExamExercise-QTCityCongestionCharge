using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace QTCityCongestionCharge.Logic.UnitTest
{
    [TestClass]
    public class FeeUnitTest
    {
        private OwnerUnitTest ownerUnitTest = new OwnerUnitTest();
        private CarUnitTest carUnitTest = new CarUnitTest();
        private DetectionUntitTest detectionUnitTest = new DetectionUntitTest();
        private PaymentUnitTest paymentUnitTest = new PaymentUnitTest();

        [TestInitialize]
        public void TestInitialize()
        {
            Task.Run(async () =>
            {
                await paymentUnitTest.DeleteControllerEntities();
                await detectionUnitTest.DeleteControllerEntities();
                await carUnitTest.DeleteControllerEntities();
                await ownerUnitTest.DeleteControllerEntities();
            }).Wait();
        }

        [TestMethod]
        public async Task Execute_TestExample01_ExpectedFee15()
        {
            var expected = 15.0;
            var now = DateTime.Now;
            using var carCtrl = new Controllers.CarsController();
            var enteringTaken = new DateTime(now.Year, now.Month, now.Day, 8, 30, 0);
            var leavingTaken = new DateTime(now.Year, now.Month, now.Day, 16, 15, 0);
            var carUnitTest = new CarUnitTest();
            var ownerUnitTest = new OwnerUnitTest();
            var detectionUnitTest = new DetectionUntitTest();

            await detectionUnitTest.DeleteControllerEntities();
            await carUnitTest.DeleteControllerEntities();
            await ownerUnitTest.DeleteControllerEntities();

            var owner = ownerUnitTest.CreateValidOwner();
            var car = carUnitTest.CreateValidFossileCar();
            var enteringDetection = detectionUnitTest.CreateValidDetection(enteringTaken, Entities.MovementType.Entering, new System.Collections.Generic.List<Entities.Car> { car });
            var leavingDetection = detectionUnitTest.CreateValidDetection(leavingTaken, Entities.MovementType.Leaving, new System.Collections.Generic.List<Entities.Car> { car });

            Assert.IsNotNull(owner);
            Assert.IsNotNull(car);
            car.Owner = owner;

            await detectionUnitTest.CreateArray_OfEntities_AndCheckAll(new[] { enteringDetection, leavingDetection });

            var actual = await carCtrl.CalculateFeeAsync(car.Id);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public async Task Execute_TestExample02_ExpectedFee91()
        {
            var expected = 91.0;
            using var carCtrl = new Controllers.CarsController();
            var enteringTaken = new DateTime(2022, 3, 7, 15, 45, 0);
            var detectionTaken1 = new DateTime(2022, 3, 9, 9, 15, 0);
            var detectionTaken2 = new DateTime(2022, 3, 10, 16, 45, 0);
            var detectionTaken3 = new DateTime(2022, 3, 11, 8, 45, 0);
            var leavingTaken = new DateTime(2022, 3, 11, 14, 15, 0);
            var carUnitTest = new CarUnitTest();
            var ownerUnitTest = new OwnerUnitTest();
            var detectionUnitTest = new DetectionUntitTest();

            await detectionUnitTest.DeleteControllerEntities();
            await carUnitTest.DeleteControllerEntities();
            await ownerUnitTest.DeleteControllerEntities();

            var owner = ownerUnitTest.CreateValidOwner();
            var car = carUnitTest.CreateValidFossileCar();
            var enteringDetection = detectionUnitTest.CreateValidDetection(enteringTaken, Entities.MovementType.Entering, new System.Collections.Generic.List<Entities.Car> { car });
            var detection1 = detectionUnitTest.CreateValidDetection(detectionTaken1, Entities.MovementType.DrivingInside, new System.Collections.Generic.List<Entities.Car> { car });
            var detection2 = detectionUnitTest.CreateValidDetection(detectionTaken2, Entities.MovementType.DrivingInside, new System.Collections.Generic.List<Entities.Car> { car });
            var detection3 = detectionUnitTest.CreateValidDetection(detectionTaken3, Entities.MovementType.DrivingInside, new System.Collections.Generic.List<Entities.Car> { car });
            var leavingDetection = detectionUnitTest.CreateValidDetection(leavingTaken, Entities.MovementType.Leaving, new System.Collections.Generic.List<Entities.Car> { car });

            Assert.IsNotNull(owner);
            Assert.IsNotNull(car);
            car.Owner = owner;

            await detectionUnitTest.CreateArray_OfEntities_AndCheckAll(new[] { enteringDetection, detection1, detection2, detection3, leavingDetection });

            var actual = await carCtrl.CalculateFeeAsync(car.Id);
            Assert.AreEqual(expected, actual);
        }
    }
}
