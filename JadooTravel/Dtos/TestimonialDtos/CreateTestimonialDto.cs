namespace JadooTravel.Dtos.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateTime Date { get; set; }
    }
}