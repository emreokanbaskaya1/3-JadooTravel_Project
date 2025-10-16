namespace JadooTravel.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
        public string DatabaseName
        {
            get => Database;
            set => Database = value;
        }
        public string CategoryCollectionName { get; set; } = string.Empty;
        public string DestinationCollectionName { get; set; } = string.Empty;
        public string FeatureCollectionName { get; set; } = string.Empty;
        public string TripPlanCollectionName { get; set; } = string.Empty;
        public string ReservationCollectionName { get; set; } = string.Empty;
        public string TestimonialCollectionName { get; set; } = string.Empty;
    }
}
