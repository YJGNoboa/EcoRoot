namespace EcoRoot.Domain.Entitites
{
    public class Crop : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime PlantingDate { get; set; }
        public DateTime? EstimatedHarvestDate { get; set; }
        public string Status { get; set; } = "Active";

        public int PlotId { get; set; }
        public Plot Plot { get; set; } = null!;

        public ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

        public override string GetSummary() =>
            $"Crop: {Name} ({Type}) — Status: {Status}";
    }
}
