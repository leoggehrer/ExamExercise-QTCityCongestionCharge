using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTCityCongestionCharge.Logic.Controllers;
using QTCityCongestionCharge.Logic.Entities;

namespace QTCityCongestionCharge.WebApi.Controllers
{
    public class CarsController : GenericController<Logic.Entities.Car, Models.BaseCar, Models.Car>
    {
        public CarsController(Logic.Controllers.CarsController controller) : base(controller)
        {
        }
    }
}
