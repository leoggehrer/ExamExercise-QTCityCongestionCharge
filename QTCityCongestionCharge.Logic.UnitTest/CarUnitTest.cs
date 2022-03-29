using Microsoft.VisualStudio.TestTools.UnitTesting;
using QTCityCongestionCharge.Logic.Controllers;
using QTCityCongestionCharge.Logic.Entities;
using System.Threading.Tasks;

namespace QTCityCongestionCharge.Logic.UnitTest
{
    [TestClass]
    public class CarUnitTest : EntityUnitTest<Entities.Car>
    {
        private CommonUnitTest CommonUnitTest { get; } = new CommonUnitTest();
        public override GenericController<Car> CreateController()
        {
            return new CarsController();
        }

        public Car CreateValidFossileCar(int ownerId)
        {
            return new Car()
            {
                OwnerId = ownerId,
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
                var entity = CreateValidFossileCar(ownerId);

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
            CommonUnitTest.DeleteAllEntities();
        }

        [TestMethod]
        public async Task Create_ValidFossileCar_ExpectedAccept()
        {
            var ownerUnitTest = new OwnerUnitTest();
            var owner = await ownerUnitTest.CreateValidOwnerAndStore();

            Assert.IsNotNull(owner);
            var entity = CreateValidFossileCar(owner.Id);

            await Create_OfEntity_AndCheck(entity);
        }
    }
}
