using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackApp.BLL.VMs.MediaFile
{
    public class CreateMediaFile
    {
        public string Name { get; set; }
        public string Type { get; set; } 
        public string Path { get; set; }
        public Guid? FeedbackId { get; set; }
    }
}
