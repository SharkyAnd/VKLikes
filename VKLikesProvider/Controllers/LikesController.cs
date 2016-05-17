using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using VKLikesProvider.Models;

namespace VKLikesProvider.Controllers
{
    public class LikesController : Controller
    {
        // GET: Likes
        public ActionResult FirstPage()
        {
            return View();
        }

        public ActionResult SecondPage()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUrlDataJson()
        {
            UrlHelper urlHelper = new UrlHelper(Request.RequestContext);
            var getLikesUrl = urlHelper.Action("GetPageLikes", "Likes");
            var likeUrl = urlHelper.Action("Like", "Likes");

            return Json(new { GetLikesUrl = getLikesUrl, LikeUrl = likeUrl }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPageLikes(int pageId)
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Like(string like)
        {           
            try
            {
                VKLike vkLike = new JavaScriptSerializer().Deserialize<VKLike>(like);
                using (LikesDBContext db = new LikesDBContext())
                {
                    db.VKLikes.Add(vkLike);
                    db.SaveChanges();
                }
                return Json(like, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public ActionResult ViewLikes()
        {
            List<VKLike> model = new List<VKLike>();

            using (LikesDBContext db = new LikesDBContext())
            {
                model = db.VKLikes.ToList();
            }

            return View(model);
        }
    }
}