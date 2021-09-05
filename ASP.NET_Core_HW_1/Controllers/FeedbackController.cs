using FeedbackApp.BLL.Interfaces;
using FeedbackApp.BLL.VMs.Feedback;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FeedbackApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        [Route("getbyid")]
        public List<InfoFeedback> GetFeedbackById(Guid id)
        {
            return _feedbackService.FindFeedbacksByFunc(m => m.Id == id);
        }

        [HttpGet]
        [Route("getall")]
        public List<InfoFeedback> GetAllFeedbacks()
        {
            return _feedbackService.FindFeedbacksByFunc(null);
        }

        [HttpPost]
        public Guid Create([FromForm] CreateFeedback feedback)
        {
            return (_feedbackService.CreateFeedbackAsync(feedback)).Result;
        }
    }
}
