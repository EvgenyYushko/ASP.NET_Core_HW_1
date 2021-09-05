using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackApp.BLL.VMs.Comment
{
    public class InfoComment
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid FeedbackId { get; set; }
        public string ProductName { get; set; }
    }
}
