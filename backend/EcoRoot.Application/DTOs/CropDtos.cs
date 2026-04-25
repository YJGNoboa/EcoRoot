namespace EcoRoot.Application.DTOs
{
    public class CropCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime PlantingDate { get; set; } = DateTime.Today;
        public DateTime? EstimatedHarvestDate { get; set; }
        public string Status { get; set; } = "Active";
        public int PlotId { get; set; }
    }

    public class CropUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime PlantingDate { get; set; }
        public DateTime? EstimatedHarvestDate { get; set; }
        public string Status { get; set; } = "Active";
        public int PlotId { get; set; }
    }

    public class CropResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime PlantingDate { get; set; }
        public DateTime? EstimatedHarvestDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int PlotId { get; set; }
        public string? PlotName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
