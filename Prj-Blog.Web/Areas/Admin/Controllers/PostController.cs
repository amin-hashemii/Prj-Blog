using Microsoft.AspNetCore.Mvc;
using Prj_Blog.CoreLayer.DTOs.Post;
using Prj_Blog.CoreLayer.Services.Post;

namespace Prj_Blog.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PostController : Controller
    {
        private readonly IPostService _postservice;

        public PostController(IPostService postservice)
        {
            _postservice = postservice;
        }

        public IActionResult Index(int pageid =1,string title="",string categoryslug="")
        {
            var param= new PostFilterParams()
            {
                CategorySlug = categoryslug ,
                PageId = pageid ,
                Take = 20,
                Title = title 
            };
            var model = _postservice.GetPostByFilter(param);
            return View(model);
        }
    }
}
