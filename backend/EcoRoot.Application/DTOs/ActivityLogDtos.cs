namespace EcoRoot.Application.DTOs
{
    public class ActivityLogCreateDto
    {
        public string Description { get; set; } = string.Empty;
        public DateTime ActivityDate { get; set; } = DateTime.Today;
        public string ActivityType { get; set; } = string.Empty;
        public int CropId { get; set; }
        public int StudentId { get; set; }
    }

    public class ActivityLogUpdateDto
    {
        public string Description { get; set; } = string.Empty;
        public DateTime ActivityDate { get; set; }
        public string ActivityType { get; set; } = string.Empty;
        public int CropId { get; set; }
        public int StudentId { get; set; }
    }

    public class ActivityLogResponseDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime ActivityDate { get; set; }
        public string ActivityType { get; set; } = string.Empty;
        public int CropId { get; set; }
        public string? CropName { get; set; }
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
