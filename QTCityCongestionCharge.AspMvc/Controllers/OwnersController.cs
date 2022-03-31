
namespace QTCityCongestionCharge.AspMvc.Controllers
{
    public class OwnersController : GenericController<Logic.Entities.Owner, Models.Owner>
    {
        public OwnersController(Logic.Controllers.OwnersController controller) : base(controller)
        {
        }
    }
}
