namespace Application06.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public string IconClass { get; set; } = string.Empty;
        public string BadgeColor { get; set; } = string.Empty;
    }
}

