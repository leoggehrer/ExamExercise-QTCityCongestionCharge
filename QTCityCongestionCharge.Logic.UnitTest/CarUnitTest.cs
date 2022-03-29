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
    }
}
