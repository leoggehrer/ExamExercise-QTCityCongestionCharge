using System.Threading.Tasks;

namespace QTCityCongestionCharge.Logic.UnitTest
{
    internal class CommonUnitTest
    {
        public OwnerUnitTest OwnerUnitTest { get; } = new OwnerUnitTest();
        public CarUnitTest CarUnitTest { get; } = new CarUnitTest();
        public DetectionUntitTest DetectionUnitTest { get; } = new DetectionUntitTest();
        public PaymentUnitTest PaymentUnitTest { get; } = new PaymentUnitTest();

        public void DeleteAllEntities()
        {
            Task.Run(async () =>
            {
                await PaymentUnitTest.DeleteControllerEntities();
                await DetectionUnitTest.DeleteControllerEntities();
                await CarUnitTest.DeleteControllerEntities();
                await OwnerUnitTest.DeleteControllerEntities();
            }).Wait();
        }
    }
}
