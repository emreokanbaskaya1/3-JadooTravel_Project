using AutoMapper; // AutoMapper for object mapping
using JadooTravel.Dtos.TripPlanDtos; // TripPlan DTOs
using JadooTravel.Entities; // TripPlan entity
using JadooTravel.Settings; // Database settings interface
using MongoDB.Driver; // MongoDB driver

namespace JadooTravel.Services.TripPlanServices // Correct namespace for TripPlan
{
    public class TripPlanService : ITripPlanService // Implements tripplan service interface
    {
        private readonly IMongoCollection<TripPlan> _tripPlanCollection; // MongoDB collection for tripplans
        private readonly IMapper _mapper; // AutoMapper instance

        public TripPlanService(IMapper mapper, IDatabaseSettings databaseSettings) // Constructor with DI
        {
            var client = new MongoClient(databaseSettings.ConnectionString); // Create MongoDB client
            var database = client.GetDatabase(databaseSettings.DatabaseName); // Get database
            _tripPlanCollection = database.GetCollection<TripPlan>(databaseSettings.TripPlanCollectionName); // Get tripplan collection
            _mapper = mapper; // Assign mapper
        }

        public async Task CreateTripPlanAsync(CreateTripPlanDto createTripPlanDto) // Create new tripplan
        {
            var value = _mapper.Map<TripPlan>(createTripPlanDto); // Map DTO to entity
            await _tripPlanCollection.InsertOneAsync(value); // Insert into MongoDB
        }

        public async Task DeleteTripPlanAsync(string id) // Delete tripplan by id
        {
            await _tripPlanCollection.DeleteOneAsync(x => x.TripPlanId == id); // Delete from MongoDB
        }

        public async Task<List<ResultTripPlanDto>> GetAllTripPlanAsync() // Get all tripplans
        {
            var values = await _tripPlanCollection.Find(x => true).ToListAsync(); // Get all from MongoDB
            return _mapper.Map<List<ResultTripPlanDto>>(values); // Map to DTO list
        }

        public async Task<GetTripPlanByIdDto> GetTripPlanByIdAsync(string id) // Get tripplan by id
        {
            var value = await _tripPlanCollection.Find(x => x.TripPlanId == id).FirstOrDefaultAsync(); // Find in MongoDB
            return _mapper.Map<GetTripPlanByIdDto>(value); // Map to DTO
        }

        public async Task UpdateTripPlanAsync(UpdateTripPlanDto updateTripPlanDto) // Update tripplan
        {
            var value = _mapper.Map<TripPlan>(updateTripPlanDto); // Map DTO to entity
            await _tripPlanCollection.FindOneAndReplaceAsync(x => x.TripPlanId == updateTripPlanDto.TripPlanId, value); // Replace in MongoDB
        }
    }
}