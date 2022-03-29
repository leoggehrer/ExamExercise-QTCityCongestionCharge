using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QTCityCongestionCharge.Logic.UnitTest
{
    [TestClass]
    public class FeeUnitTest : EntityUnitTest<Entities.Owner>
    {
        protected override Controllers.GenericController<Entities.Owner> CreateController()
        {
            return new Controllers.OwnersController();
        }
    }
}
