namespace JadooTravel.Dtos.FeatureDtos
{
    public class CreateFeatureDto  
    {
        public string Title { get; set; } = string.Empty;
        public string MainTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? VideoUrl { get; set; }
        // Create'te Id yok çünkü MongoDB otomatik oluşturur
    }
}
