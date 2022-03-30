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

        /// <summary>
        /// Driving to Linz for work with a fossile car
        /// A passenger car running on fossile fuels enters Linz on a Tuesday at 8:30am and leaves Linz on the same day at 4:15pm.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Driving_WithFossileCarExample01_ExpectedFee15()
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
        /// <summary>
        /// Driving to Linz for work with a fossile van
        /// A passenger car running on fossile fuels enters Linz on a Tuesday at 8:30am and leaves Linz on the same day at 4:15pm.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Driving_WithFossileVanExample01_ExpectedFee22_5()
        {
            var expected = 22.5;
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
            var car = carUnitTest.CreateValidFossileVan();
            var enteringDetection = detectionUnitTest.CreateValidDetection(enteringTaken, Entities.MovementType.Entering, new System.Collections.Generic.List<Entities.Car> { car });
            var leavingDetection = detectionUnitTest.CreateValidDetection(leavingTaken, Entities.MovementType.Leaving, new System.Collections.Generic.List<Entities.Car> { car });

            Assert.IsNotNull(owner);
            Assert.IsNotNull(car);
            car.Owner = owner;

            await detectionUnitTest.CreateArray_OfEntities_AndCheckAll(new[] { enteringDetection, leavingDetection });

            var actual = await carCtrl.CalculateFeeAsync(car.Id);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Driving to Linz for work with a fossile motorcycle
        /// A passenger car running on fossile fuels enters Linz on a Tuesday at 8:30am and leaves Linz on the same day at 4:15pm.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Driving_WithFossileMotorcycleExample01_ExpectedFee7_5()
        {
            var expected = 7.5;
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
            var car = carUnitTest.CreateValidFossileMotorcycle();
            var enteringDetection = detectionUnitTest.CreateValidDetection(enteringTaken, Entities.MovementType.Entering, new System.Collections.Generic.List<Entities.Car> { car });
            var leavingDetection = detectionUnitTest.CreateValidDetection(leavingTaken, Entities.MovementType.Leaving, new System.Collections.Generic.List<Entities.Car> { car });

            Assert.IsNotNull(owner);
            Assert.IsNotNull(car);
            car.Owner = owner;

            await detectionUnitTest.CreateArray_OfEntities_AndCheckAll(new[] { enteringDetection, leavingDetection });

            var actual = await carCtrl.CalculateFeeAsync(car.Id);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Driving to Linz for work with a HeV car
        /// A passenger car running on fossile fuels enters Linz on a Tuesday at 8:30am and leaves Linz on the same day at 4:15pm.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Driving_WithFossileMotorcycleExample01_ExpectedFee6()
        {
            var expected = 6.0;
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
            var car = carUnitTest.CreateValidHeVCar();
            var enteringDetection = detectionUnitTest.CreateValidDetection(enteringTaken, Entities.MovementType.Entering, new System.Collections.Generic.List<Entities.Car> { car });
            var leavingDetection = detectionUnitTest.CreateValidDetection(leavingTaken, Entities.MovementType.Leaving, new System.Collections.Generic.List<Entities.Car> { car });

            Assert.IsNotNull(owner);
            Assert.IsNotNull(car);
            car.Owner = owner;

            await detectionUnitTest.CreateArray_OfEntities_AndCheckAll(new[] { enteringDetection, leavingDetection });

            var actual = await carCtrl.CalculateFeeAsync(car.Id);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Staying in Linz for vacation with fossile car
        /// A passenger car running on fossile fuels enters Linz on a Monday at 3:45pm and leaves Linz 
        /// on the following Friday at 2:15pm.It was detected driving on streets inside Linz on Wednesday at 9:15am, 
        /// on Thursday at 4:45pm, and on Friday at 8:45am.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Driving_WithFossileCarExample02_ExpectedFee91()
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
        /// <summary>
        /// Staying in Linz for vacation with fossile van
        /// A passenger car running on fossile fuels enters Linz on a Monday at 3:45pm and leaves Linz 
        /// on the following Friday at 2:15pm.It was detected driving on streets inside Linz on Wednesday at 9:15am, 
        /// on Thursday at 4:45pm, and on Friday at 8:45am.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Driving_WithFossileVanExample02_ExpectedFee136_5()
        {
            var expected = 136.5;
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
            var car = carUnitTest.CreateValidFossileVan();
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
        /// <summary>
        /// Staying in Linz for vacation with fossile lorry
        /// A passenger car running on fossile fuels enters Linz on a Monday at 3:45pm and leaves Linz 
        /// on the following Friday at 2:15pm.It was detected driving on streets inside Linz on Wednesday at 9:15am, 
        /// on Thursday at 4:45pm, and on Friday at 8:45am.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Driving_WithFossileLorryExample02_ExpectedFee136_5()
        {
            var expected = 136.5;
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
            var car = carUnitTest.CreateValidFossileLorry();
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
        /// <summary>
        /// Staying in Linz for vacation with fossile motorcycle
        /// A passenger car running on fossile fuels enters Linz on a Monday at 3:45pm and leaves Linz 
        /// on the following Friday at 2:15pm.It was detected driving on streets inside Linz on Wednesday at 9:15am, 
        /// on Thursday at 4:45pm, and on Friday at 8:45am.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Driving_WithFossileMotorcycleExample02_ExpectedFee45_5()
        {
            var expected = 45.5;
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
            var car = carUnitTest.CreateValidFossileMotorcycle();
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

        /// <summary>
        /// Driving to Linz for party with a fossile car
        /// A passenger car running on fossile fuels enters Linz on a Saturday at 5:00pm and leaves Linz 
        /// on the following calendar day at 1:30am(night).
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Driving_WithFossileCarExample03_ExpectedFee0()
        {
            var expected = 0.0;
            using var carCtrl = new Controllers.CarsController();
            var enteringTaken = new DateTime(2022, 3, 19, 17, 00, 0);
            var leavingTaken = new DateTime(2022, 3, 20, 1, 30, 0);
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
    }
}
