namespace EcoRoot.Domain.Entitites
{
    public class Plot : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Area { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? Description { get; set; }

        public ICollection<Crop> Crops { get; set; } = new List<Crop>();

        public override string GetSummary() =>
            $"Plot: {Name} ({Area} m²) — {Location}";
    }
}
