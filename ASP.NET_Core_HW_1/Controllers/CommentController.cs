using FeedbackApp.BLL.Interfaces;
using FeedbackApp.BLL.VMs.Comment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Route("getbyid")]
        public List<InfoComment> GetCommentByFeedbackId(Guid id)
        {
            return _commentService.FindCommentsByFunc(m => m.FeedbackId == id);
        }

        [HttpGet]
        [Route("getall")]
        public List<InfoComment> GetAllComments()
        {
            return _commentService.FindCommentsByFunc(null);
        }

        [HttpPost]
        public Guid Create([FromForm] CreateComment comment)
        {
            return (_commentService.CreateCommentAsync(comment)).Result;
        }
    }
}
