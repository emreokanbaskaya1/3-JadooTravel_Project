using JadooTravel.Services.TripPlanServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _DefaultBookingStepsComponentPartial : ViewComponent
    {
        private readonly ITripPlanService _tripPlanService;

        public _DefaultBookingStepsComponentPartial(ITripPlanService tripPlanService)
        {
            _tripPlanService = tripPlanService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _tripPlanService.GetAllTripPlanAsync();
            return View(values);
        }
    }
}
