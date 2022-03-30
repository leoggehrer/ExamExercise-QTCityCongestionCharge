using Microsoft.VisualStudio.TestTools.UnitTesting;
using QTCityCongestionCharge.Logic.Controllers;
using QTCityCongestionCharge.Logic.Entities;
using System.Threading.Tasks;

namespace QTCityCongestionCharge.Logic.UnitTest
{
    [TestClass]
    public class CarUnitTest : EntityUnitTest<Entities.Car>
    {
        public override GenericController<Car> CreateController()
        {
            return new CarsController();
        }

        public Car CreateValidFossileCar()
        {
            return new Car()
            {
                CarType = CarType.PassengerCar,
                LicensePlate = $"L-FOSSI{++Counter}",
                Make = $"ErdÖl{++Counter}",
                Model = "Verbrenner",
                Color = "Schwarz",
                IsElectricOrHybrid = false,
            };
        }
        public Car CreateValidFossileVan()
        {
            return new Car()
            {
                CarType = CarType.Van,
                LicensePlate = $"L-VAN{++Counter}",
                Make = $"ErdÖl{++Counter}",
                Model = "Verbrenner",
                Color = "Schwarz",
                IsElectricOrHybrid = false,
            };
        }
        public Car CreateValidFossileLorry()
        {
            return new Car()
            {
                CarType = CarType.Lorry,
                LicensePlate = $"L-LORRY{++Counter}",
                Make = $"ErdÖl{++Counter}",
                Model = "Verbrenner",
                Color = "Schwarz",
                IsElectricOrHybrid = false,
            };
        }
        public Car CreateValidFossileMotorcycle()
        {
            return new Car()
            {
                CarType = CarType.Motorcycle,
                LicensePlate = $"L-MCYCLE{++Counter}",
                Make = $"ErdÖl{++Counter}",
                Model = "Verbrenner",
                Color = "Schwarz",
                IsElectricOrHybrid = false,
            };
        }
        public Car CreateValidHeVCar()
        {
            return new Car()
            {
                CarType = CarType.PassengerCar,
                LicensePlate = $"L-MCYCLE{++Counter}",
                Make = $"ErdÖl{++Counter}",
                Model = "Verbrenner",
                Color = "Schwarz",
                IsElectricOrHybrid = true,
            };
        }
        public async Task<Car> CreateValidFossilCarAndStore(int ownerId)
        {
            try
            {
                var ctrl = CreateController();
                var entity = CreateValidFossileCar();

                entity.OwnerId = ownerId;

                var insertEntity = await ctrl.InsertAsync(entity);
                await ctrl.SaveChangesAsync();
                return insertEntity;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Task.Run(async () => await DeleteControllerEntities()).Wait();
        }

        [TestMethod]
        public async Task Create_ValidFossileCar_ExpectedAccept()
        {
            var ownerUnitTest = new OwnerUnitTest();
            var owner = ownerUnitTest.CreateValidOwner();

            Assert.IsNotNull(owner);
            var entity = CreateValidFossileCar();

            entity.Owner = owner;
            await Create_OfEntity_AndCheck(entity);
        }
        [TestMethod]
        public async Task Create_ValidFossileVan_ExpectedAccept()
        {
            var ownerUnitTest = new OwnerUnitTest();
            var owner = ownerUnitTest.CreateValidOwner();

            Assert.IsNotNull(owner);
            var entity = CreateValidFossileVan();

            entity.Owner = owner;
            await Create_OfEntity_AndCheck(entity);
        }
        [TestMethod]
        public async Task Create_ValidFossileLorry_ExpectedAccept()
        {
            var ownerUnitTest = new OwnerUnitTest();
            var owner = ownerUnitTest.CreateValidOwner();

            Assert.IsNotNull(owner);
            var entity = CreateValidFossileLorry();

            entity.Owner = owner;
            await Create_OfEntity_AndCheck(entity);
        }
        [TestMethod]
        public async Task Create_ValidFossileMotorcycle_ExpectedAccept()
        {
            var ownerUnitTest = new OwnerUnitTest();
            var owner = ownerUnitTest.CreateValidOwner();

            Assert.IsNotNull(owner);
            var entity = CreateValidFossileMotorcycle();

            entity.Owner = owner;
            await Create_OfEntity_AndCheck(entity);
        }
        [TestMethod]
        public async Task Create_ValidHeVCar_ExpectedAccept()
        {
            var ownerUnitTest = new OwnerUnitTest();
            var owner = ownerUnitTest.CreateValidOwner();

            Assert.IsNotNull(owner);
            var entity = CreateValidHeVCar();

            entity.Owner = owner;
            await Create_OfEntity_AndCheck(entity);
        }
    }
}
