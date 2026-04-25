namespace EcoRoot.Domain.Entitites
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string? Email { get; set; }

        public ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

        public override string GetSummary() =>
            $"Student: {FirstName} {LastName} — Grade: {Grade}";
    }
}
