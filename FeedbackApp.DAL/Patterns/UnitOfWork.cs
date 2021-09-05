using FeedbackApp.Models;
using System;
using System.Threading.Tasks;

namespace FeedbackApp.DAL.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApDbContext _db;

        public UnitOfWork(ApDbContext db)
        {
            _db = db;
        }

        private IRepository<Product> _products;
        private IRepository<MediaFile> _mediaFiles;
        private IRepository<Feedback> _feedbacks;
        private IRepository<Comment> _comments;

        public IRepository<Product> Products => _products ?? (_products = new Repository<Product>(_db));
        public IRepository<MediaFile> MediaFiles => _mediaFiles ?? (_mediaFiles = new Repository<MediaFile>(_db));
        public IRepository<Feedback> Feedbacks => _feedbacks ?? (_feedbacks = new Repository<Feedback>(_db));
        public IRepository<Comment> Comments => _comments ?? (_comments = new Repository<Comment>(_db));

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (this._disposed)
                return;
            if (disposing)
            {
                _db.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}