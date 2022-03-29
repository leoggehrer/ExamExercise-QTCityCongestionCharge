using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public async Task CreateTestCase01Async()
        {

        }
    }
}
