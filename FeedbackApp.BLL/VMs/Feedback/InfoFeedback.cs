using FeedbackApp.BLL.VMs.Comment;
using FeedbackApp.BLL.VMs.MediaFile;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackApp.BLL.VMs.Feedback
{
    public class InfoFeedback
    {
        public DateTime CreationDate { get; set; }
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
        public string ProductName { get; set; }
        public List<InfoComment> Comments { get; set; } = new List<InfoComment>();
        public List<CreateMediaFile> MediaFiles { get; set; } = new List<CreateMediaFile>();
    }
}
