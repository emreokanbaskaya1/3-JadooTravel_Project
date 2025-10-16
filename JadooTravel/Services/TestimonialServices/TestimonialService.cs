using AutoMapper; // AutoMapper for object mapping
using JadooTravel.Dtos.TestimonialDtos; // Testimonial DTOs
using JadooTravel.Entities; // Testimonial entity
using JadooTravel.Settings; // Database settings interface
using MongoDB.Driver; // MongoDB driver

namespace JadooTravel.Services.TestimonialServices // Correct namespace for Testimonial
{
    public class TestimonialService : ITestimonialService // Implements testimonial service interface
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection; // MongoDB collection for testimonials
        private readonly IMapper _mapper; // AutoMapper instance

        public TestimonialService(IMapper mapper, IDatabaseSettings databaseSettings) // Constructor with DI
        {
            var client = new MongoClient(databaseSettings.ConnectionString); // Create MongoDB client
            var database = client.GetDatabase(databaseSettings.DatabaseName); // Get database
            _testimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName); // Get testimonial collection
            _mapper = mapper; // Assign mapper
        }

        public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto) // Create new testimonial
        {
            var value = _mapper.Map<Testimonial>(createTestimonialDto); // Map DTO to entity
            await _testimonialCollection.InsertOneAsync(value); // Insert into MongoDB
        }

        public async Task DeleteTestimonialAsync(string id) // Delete testimonial by id
        {
            await _testimonialCollection.DeleteOneAsync(x => x.TestimonialId == id); // Delete from MongoDB
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync() // Get all testimonials
        {
            var values = await _testimonialCollection.Find(x => true).ToListAsync(); // Get all from MongoDB
            return _mapper.Map<List<ResultTestimonialDto>>(values); // Map to DTO list
        }

        public async Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id) // Get testimonial by id
        {
            var value = await _testimonialCollection.Find(x => x.TestimonialId == id).FirstOrDefaultAsync(); // Find in MongoDB
            return _mapper.Map<GetTestimonialByIdDto>(value); // Map to DTO
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto) // Update testimonial
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto); // Map DTO to entity
            await _testimonialCollection.FindOneAndReplaceAsync(x => x.TestimonialId == updateTestimonialDto.TestimonialId, value); // Replace in MongoDB
        }
    }
}