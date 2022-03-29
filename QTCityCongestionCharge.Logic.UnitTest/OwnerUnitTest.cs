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
    public class OwnerUnitTest : EntityUnitTest<Entities.Owner>
    {
        private CommonUnitTest CommonUnitTest { get; } = new CommonUnitTest();
        public override GenericController<Owner> CreateController()
        {
            return new OwnersController();
        }

        public Owner CreateValidOwner()
        {
            return new Owner()
            {
                FirstName = $"FirstName{++Counter}",
                LastName = $"LastName{++Counter}",
                Address = $"4020 Linz, Europastraße {++Counter}",
            };
        }
        public async Task<Owner> CreateValidOwnerAndStore()
        {
            var ctrl = CreateController();
            var entity = CreateValidOwner();

            var insertEntity = await ctrl.InsertAsync(entity);
            await ctrl.SaveChangesAsync();
            return insertEntity;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            CommonUnitTest.DeleteAllEntities();
        }

        [TestMethod]
        public async Task Create_ValidOwner_ExpectedAccept()
        {
            var entity = CreateValidOwner();

            await Create_OfEntity_AndCheck(entity);
        }

    }
}
