using FeedbackApp.BLL.VMs.MediaFile;
using FeedbackApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedbackApp.BLL.Interfaces
{
    public interface IMediaFileService
    {
        Task<Guid> CreateMediaFileAsync(CreateMediaFile mediaFile); 
        List<CreateMediaFile> FindMediaFilesByFunc(Func<MediaFile, bool> func);
    }
}
