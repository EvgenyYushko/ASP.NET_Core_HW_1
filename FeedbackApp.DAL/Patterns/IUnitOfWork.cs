using FeedbackApp.Models;
using System;
using System.Threading.Tasks;

namespace FeedbackApp.DAL.Patterns
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<MediaFile> MediaFiles { get; }
        IRepository<Feedback> Feedbacks { get; }
        IRepository<Comment> Comments { get; }

        Task SaveAsync();
    }
}
