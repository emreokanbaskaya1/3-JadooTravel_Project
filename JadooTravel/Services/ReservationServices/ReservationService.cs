using AutoMapper; // AutoMapper for object mapping
using JadooTravel.Dtos.ReservationDtos; // Reservation DTOs
using JadooTravel.Entities; // Reservation entity
using JadooTravel.Settings; // Database settings interface
using MongoDB.Driver; // MongoDB driver

namespace JadooTravel.Services.ReservationServices // Correct namespace for Reservation
{
    public class ReservationService : IReservationService // Implements reservation service interface
    {
        private readonly IMongoCollection<Reservation> _reservationCollection; // MongoDB collection for reservations
        private readonly IMapper _mapper; // AutoMapper instance

        public ReservationService(IMapper mapper, IDatabaseSettings databaseSettings) // Constructor with DI
        {
            var client = new MongoClient(databaseSettings.ConnectionString); // Create MongoDB client
            var database = client.GetDatabase(databaseSettings.DatabaseName); // Get database
            _reservationCollection = database.GetCollection<Reservation>(databaseSettings.ReservationCollectionName); // Get reservation collection
            _mapper = mapper; // Assign mapper
        }

        public async Task CreateReservationAsync(CreateReservationDto createReservationDto) // Create new reservation
        {
            var value = _mapper.Map<Reservation>(createReservationDto); // Map DTO to entity
            await _reservationCollection.InsertOneAsync(value); // Insert into MongoDB
        }

        public async Task DeleteReservationAsync(string id) // Delete reservation by id
        {
            await _reservationCollection.DeleteOneAsync(x => x.ReservationId == id); // Delete from MongoDB
        }

        public async Task<List<ResultReservationDto>> GetAllReservationAsync() // Get all reservations
        {
            var values = await _reservationCollection.Find(x => true).ToListAsync(); // Get all from MongoDB
            return _mapper.Map<List<ResultReservationDto>>(values); // Map to DTO list
        }

        public async Task<GetReservationByIdDto> GetReservationByIdAsync(string id) // Get reservation by id
        {
            var value = await _reservationCollection.Find(x => x.ReservationId == id).FirstOrDefaultAsync(); // Find in MongoDB
            return _mapper.Map<GetReservationByIdDto>(value); // Map to DTO
        }

        public async Task UpdateReservationAsync(UpdateReservationDto updateReservationDto) // Update reservation
        {
            var value = _mapper.Map<Reservation>(updateReservationDto); // Map DTO to entity
            await _reservationCollection.FindOneAndReplaceAsync(x => x.ReservationId == updateReservationDto.ReservationId, value); // Replace in MongoDB
        }
    }
}
