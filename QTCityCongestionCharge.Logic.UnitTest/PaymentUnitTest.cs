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
    public class PaymentUnitTest : EntityUnitTest<Entities.Payment>
    {
        public override GenericController<Payment> CreateController()
        {
            return new PaymentsController();
        }
    }
}
