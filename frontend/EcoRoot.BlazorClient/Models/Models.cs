namespace EcoRoot.BlazorClient.Models
{
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }

    public class PlotResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Area { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class PlotForm
    {
        public string Name { get; set; } = string.Empty;
        public decimal Area { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class CropResponse
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

    public class CropForm
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime PlantingDate { get; set; } = DateTime.Today;
        public DateTime? EstimatedHarvestDate { get; set; }
        public string Status { get; set; } = "Active";
        public int PlotId { get; set; }
    }

    public class StudentResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class StudentForm
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string? Email { get; set; }
    }

    public class ActivityLogResponse
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

    public class ActivityLogForm
    {
        public string Description { get; set; } = string.Empty;
        public DateTime ActivityDate { get; set; } = DateTime.Today;
        public string ActivityType { get; set; } = string.Empty;
        public int CropId { get; set; }
        public int StudentId { get; set; }
    }
}
