using lab9kos.Models.Domain;
using Microsoft.AspNetCore.Mvc.Filters;

namespace lab9kos.Filters
{
    public class GebruikerFilter : ActionFilterAttribute
    {
        private readonly IGebruikerRepository _gebruikerRepository;
        private Gebruiker _gebruiker;

        public GebruikerFilter(IGebruikerRepository gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
                _gebruiker = _gebruikerRepository.GetByEmail(context.HttpContext.User.Identity.Name);
            context.ActionArguments["gebruiker"] = _gebruiker;
            base.OnActionExecuting(context);
        }
    }
}