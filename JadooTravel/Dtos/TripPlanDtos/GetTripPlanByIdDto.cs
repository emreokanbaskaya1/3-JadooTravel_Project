namespace JadooTravel.Dtos.TripPlanDtos
{
    public class GetTripPlanByIdDto
    {
        public string TripPlanId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
    }
}