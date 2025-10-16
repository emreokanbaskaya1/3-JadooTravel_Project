namespace JadooTravel.Dtos.FeatureDtos
{
    public class GetFeatureByIdDto
    {
        // ✅ Id VAR
        public string FeatureId { get; set; } = string.Empty;
        // ✅ Genellikle TÜM alanlar var (detay sayfası için)
        public string Title { get; set; } = string.Empty;
        public string MainTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
    }
}
