using FeedbackApp.BLL.Interfaces;
using FeedbackApp.BLL.VMs.Comment;
using FeedbackApp.BLL.VMs.Feedback;
using FeedbackApp.BLL.VMs.MediaFile;
using FeedbackApp.BLL.VMs.Product;
using FeedbackApp.DAL.Patterns;
using FeedbackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApp.BLL.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _db;
        private readonly IProductService _productService;
        private readonly IMediaFileService _mediaFileService;

        public FeedbackService(IUnitOfWork db, IProductService productService, IMediaFileService mediaFileService)
        {
            this._db = db;
            this._productService = productService;
            this._mediaFileService = mediaFileService;
        }

        public async Task<Guid> CreateFeedbackAsync(CreateFeedback feedback)
        {
            try
            {
                var productId = await _productService
                    .CreateProductAsync(new CreateProduct() 
                    { 
                        Name = feedback.ProductName, 
                        Category = feedback.ProductCategory 
                    });
               
                var dbFeedback = new Feedback()
                {
                    AuthorName = feedback.AuthorName,
                    CreationDate = DateTime.Now,
                    ProductId = productId,
                    Rate = feedback.Rate,
                    Text = feedback.Text
                };
                dbFeedback = await _db.Feedbacks.CreateAsync(dbFeedback);


                if (feedback.MediaFiles != null && feedback.MediaFiles.Any())
                {
                    feedback.MediaFiles.Select(m => { 
                        m.FeedbackId = dbFeedback.Id;  
                        return _mediaFileService.CreateMediaFileAsync(m); 
                    });
                }

                return dbFeedback.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<InfoFeedback> FindFeedbacksByFunc(Func<Feedback, bool> func)
        {
            try
            {
                List<Feedback> dbFeedbacks;
                if (func == null) 
                { 
                    dbFeedbacks = _db.Feedbacks.GetAll().ToList(); 
                }
                else
                {
                    dbFeedbacks = _db.Feedbacks.GetAll().Where(func).ToList();
                }
                return dbFeedbacks.Select(m =>
                                        {
                                            return new InfoFeedback()
                                            {
                                                CreationDate = m.CreationDate,
                                                AuthorName = m.AuthorName,
                                                ProductName = m.Product.Name,
                                                Rate = m.Rate,
                                                Text = m.Text,
                                                Comments = m.Comments.Select(n =>
                                                {
                                                    return new InfoComment()
                                                    {
                                                        CreationDate = n.CreationDate,
                                                        AuthorName = n.AuthorName,
                                                        ProductName = n.Feedback.Product.Name,
                                                        Text = n.Text,
                                                        FeedbackId = n.FeedbackId
                                                    };
                                                }).ToList(),
                                                MediaFiles = m.MediaFiles.Select(e =>
                                                {
                                                    return new CreateMediaFile()
                                                    {
                                                        FeedbackId = e.FeedbackId,
                                                        Name = e.Name,
                                                        Path = e.Path,
                                                        Type = e.Type
                                                    };
                                                }).ToList()
                                            };
                                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
