namespace EcoRoot.Application.DTOs
{
    public class StudentCreateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string? Email { get; set; }
    }

    public class StudentUpdateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string? Email { get; set; }
    }

    public class StudentResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
