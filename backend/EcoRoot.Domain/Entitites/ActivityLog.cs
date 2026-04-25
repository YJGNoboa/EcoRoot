namespace EcoRoot.Domain.Entitites
{
    public class ActivityLog : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public DateTime ActivityDate { get; set; }
        public string ActivityType { get; set; } = string.Empty;

        public int CropId { get; set; }
        public Crop Crop { get; set; } = null!;

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public override string GetSummary() =>
            $"Activity: {ActivityType} — {ActivityDate:dd/MM/yyyy}";
    }
}
