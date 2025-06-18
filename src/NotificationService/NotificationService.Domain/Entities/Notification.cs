using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }

        public Notification() {} //Par EF Core

        public Notification(string message)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            CreatedDate = DateTime.UtcNow;
        }
    }
}
