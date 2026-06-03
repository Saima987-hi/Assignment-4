using Application06.Models;

namespace Application06.Services
{
    public class NotificationService
    {
        private readonly NotificationConfig _config;

        // Simulated notification data pool
        private static readonly List<Notification> _notificationPool = new()
        {
            new Notification { Id = 1,  Title = "New Message",       Message = "You have received a new message from Ali Hassan. He wants to discuss the project timeline.",          Category = "Message",  Timestamp = DateTime.Now.AddMinutes(-2),  IsRead = false, IconClass = "bi-envelope-fill",      BadgeColor = "#4f8ef7" },
            new Notification { Id = 2,  Title = "System Update",     Message = "A critical system update (v2.5.1) is available. Please update to ensure security and performance.",  Category = "System",   Timestamp = DateTime.Now.AddMinutes(-15), IsRead = false, IconClass = "bi-gear-fill",          BadgeColor = "#f7a24f" },
            new Notification { Id = 3,  Title = "Task Completed",    Message = "Your scheduled task 'Database Backup' has completed successfully at 03:00 AM.",                     Category = "Task",     Timestamp = DateTime.Now.AddMinutes(-30), IsRead = true,  IconClass = "bi-check-circle-fill",  BadgeColor = "#4fcf70" },
            new Notification { Id = 4,  Title = "Login Alert",       Message = "A new login was detected from Lahore, Pakistan (IP: 203.99.12.45). Was this you?",                  Category = "Security", Timestamp = DateTime.Now.AddHours(-1),   IsRead = false, IconClass = "bi-shield-fill",        BadgeColor = "#f74f4f" },
            new Notification { Id = 5,  Title = "Reminder",          Message = "You have a meeting scheduled with the development team in 30 minutes. Check your calendar.",         Category = "Reminder", Timestamp = DateTime.Now.AddHours(-2),   IsRead = true,  IconClass = "bi-bell-fill",          BadgeColor = "#a24ff7" },
            new Notification { Id = 6,  Title = "Payment Received",  Message = "Payment of PKR 45,000 has been credited to your account from Client XYZ Corp.",                    Category = "Finance",  Timestamp = DateTime.Now.AddHours(-3),   IsRead = false, IconClass = "bi-currency-dollar",    BadgeColor = "#4fcf70" },
            new Notification { Id = 7,  Title = "File Shared",       Message = "Sara Khan has shared 'Q4_Report_Final.pdf' with you. Click to view the document.",                  Category = "Files",    Timestamp = DateTime.Now.AddHours(-4),   IsRead = true,  IconClass = "bi-file-earmark-fill",  BadgeColor = "#4f8ef7" },
            new Notification { Id = 8,  Title = "Server Warning",    Message = "CPU usage on Production Server #3 has exceeded 85%. Monitor closely to avoid downtime.",            Category = "System",   Timestamp = DateTime.Now.AddHours(-5),   IsRead = false, IconClass = "bi-exclamation-triangle-fill", BadgeColor = "#f7a24f" },
            new Notification { Id = 9,  Title = "New Comment",       Message = "Usman Tariq commented on your post: 'Great work on the new feature! Looking forward to testing it.'", Category = "Social", Timestamp = DateTime.Now.AddHours(-6),   IsRead = true,  IconClass = "bi-chat-fill",          BadgeColor = "#4f8ef7" },
            new Notification { Id = 10, Title = "Subscription",      Message = "Your Premium subscription renews in 3 days on June 6, 2026. Ensure payment method is updated.",    Category = "Finance",  Timestamp = DateTime.Now.AddHours(-8),   IsRead = false, IconClass = "bi-star-fill",          BadgeColor = "#f7e24f" },
        };

        public NotificationService(NotificationConfig config)
        {
            _config = config;
        }

        public Task<List<Notification>> GetNotificationsAsync(int? numberOfNotifications = null)
        {
            int count = numberOfNotifications ?? _config.DefaultNumberOfNotifications;
            count = Math.Clamp(count, 1, _notificationPool.Count);

            var result = _notificationPool.Take(count).ToList();
            return Task.FromResult(result);
        }

        public string GetCurrentStyle() => _config.NotificationStyle;

        public int GetDefaultCount() => _config.DefaultNumberOfNotifications;
    }
}
