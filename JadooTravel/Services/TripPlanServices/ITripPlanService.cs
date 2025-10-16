using JadooTravel.Dtos.TripPlanDtos;

namespace JadooTravel.Services.TripPlanServices
{
    public interface ITripPlanService
    {
        Task<List<ResultTripPlanDto>> GetAllTripPlanAsync();
        Task CreateTripPlanAsync(CreateTripPlanDto createTripPlanDto);
        Task UpdateTripPlanAsync(UpdateTripPlanDto updateTripPlanDto);
        Task DeleteTripPlanAsync(string id);
        Task<GetTripPlanByIdDto> GetTripPlanByIdAsync(string id);
    }
}