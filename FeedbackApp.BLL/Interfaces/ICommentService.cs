using FeedbackApp.BLL.VMs.Comment;
using FeedbackApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedbackApp.BLL.Interfaces
{
    public interface ICommentService
    {
        Task<Guid> CreateCommentAsync(CreateComment comment);  
        List<InfoComment> FindCommentsByFunc(Func<Comment, bool> func);
    }
}
