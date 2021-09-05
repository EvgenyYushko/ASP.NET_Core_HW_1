using System;

namespace FeedbackApp.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
