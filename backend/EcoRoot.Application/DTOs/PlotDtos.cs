namespace EcoRoot.Application.DTOs
{
    public class PlotCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Area { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class PlotUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Area { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class PlotResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Area { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
