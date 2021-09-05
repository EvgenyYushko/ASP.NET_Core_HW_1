using FeedbackApp.BLL.VMs.Feedback;
using FeedbackApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedbackApp.BLL.Interfaces
{
    public interface IFeedbackService
    {
        Task<Guid> CreateFeedbackAsync(CreateFeedback feedback);
        List<InfoFeedback> FindFeedbacksByFunc(Func<Feedback, bool> func);
    }
}
