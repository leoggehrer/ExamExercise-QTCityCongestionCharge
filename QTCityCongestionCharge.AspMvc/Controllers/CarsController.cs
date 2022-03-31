using System.Linq;

namespace QTCityCongestionCharge.AspMvc.Controllers
{
    public class CarsController : GenericController<Logic.Entities.Car, Models.Car>
    {
        private List<Models.Owner>? owners = null;
        private List<Models.Owner> Owners
        {
            get
            {
                if (owners == null)
                {
                    using var ctrl = new Logic.Controllers.OwnersController(Controller);

                    Task.Run(async () =>
                    {
                        var entities = await ctrl.GetAllAsync();

                        owners = new List<Models.Owner>();
                        foreach (var item in entities)
                        {
                            var model = new Models.Owner();

                            model.CopyFrom(item);
                            owners.Add(model);
                        }

                    }).Wait();
                }
                return owners ?? new List<Models.Owner>();
            }
        }
        public CarsController(Logic.Controllers.CarsController controller) : base(controller)
        {
        }

        protected override Models.Car ToModel(Logic.Entities.Car entity)
        {
            var result = base.ToModel(entity);

            result.Owners = Owners;
            return result;
        }
    }
}
