using System.Collections.Generic;

namespace FeedbackApp.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public virtual List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
