using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FolloweesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Followees
        public ActionResult Followee()
        {
            var artists = _unitOfWork.Followings.GetFollowees(User.Identity.GetUserId());

            return View(artists);
        }
    }
}