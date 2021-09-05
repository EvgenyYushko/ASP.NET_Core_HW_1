using FeedbackApp.BLL.Interfaces;
using FeedbackApp.BLL.VMs.MediaFile;
using FeedbackApp.DAL.Patterns;
using FeedbackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApp.BLL.Services
{
    public class MediaFileService : IMediaFileService
    {
        private readonly IUnitOfWork _db;

        public MediaFileService(IUnitOfWork db)
        {
            this._db = db;
        }

        public async Task<Guid> CreateMediaFileAsync(CreateMediaFile mediaFile)
        {
            try
            {
                var dbMediaFile = new MediaFile()
                {
                    FeedbackId = mediaFile.FeedbackId.Value,
                    Name = mediaFile.Name,
                    Path = mediaFile.Path,
                    Type = mediaFile.Type
                };
                dbMediaFile = await _db.MediaFiles.CreateAsync(dbMediaFile);
                return dbMediaFile.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CreateMediaFile> FindMediaFilesByFunc(Func<MediaFile, bool> func)
        {
            try
            {
                var dbMediaFiles = _db.MediaFiles.GetAll().Where(func). 
                                                      Select(m =>
                                                      {
                                                          return new CreateMediaFile()
                                                          {
                                                              FeedbackId = m.FeedbackId,
                                                              Name = m.Name,
                                                              Path = m.Path,
                                                              Type = m.Type
                                                          };
                                                      }).ToList();
                return dbMediaFiles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
