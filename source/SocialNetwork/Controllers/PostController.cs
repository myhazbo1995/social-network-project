using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using SocialNetwork.Model.Models;
using SocialNetwork.Properties;
using SocialNetwork.Service;
using SocialNetwork.Web.Core.Extensions;
using SocialNetwork.Web.Mailers;
using SocialNetwork.Web.ViewModels;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly IMetricService metricService;
        private readonly IFocusService focusService;
        private readonly ISupportService supportService;
        private readonly IUpdateService updateService;
        private readonly ICommentService commentService;
        private readonly IUserService userService;
        public readonly ISecurityTokenService securityTokenService;
        public readonly ISupportInvitationService supportInvitationService;
        private readonly IGoalStatusService goalStatusService;
        private readonly ICommentUserService commentUserService;
        private readonly IUpdateSupportService updateSupportService;

        private IUserMailer userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get { return userMailer; }
            set { userMailer = value; }
        }

        public PostController(IPostService postService, IMetricService metricService, IFocusService focusService, ISupportService supportService, IUpdateService updateService, ICommentService commentService, IUserService userService, ISecurityTokenService securityTokenService, ISupportInvitationService supportInvitationService, IGoalStatusService goalStatusService, ICommentUserService commentUserService, IUpdateSupportService updateSupportService)
        {
            this.postService = postService;
            this.supportInvitationService = supportInvitationService;
            this.metricService = metricService;
            this.focusService = focusService;
            this.supportService = supportService;
            this.updateService = updateService;
            this.commentService = commentService;
            this.userService = userService;
            this.securityTokenService = securityTokenService;
            this.goalStatusService = goalStatusService;
            this.commentUserService = commentUserService;
            this.updateSupportService = updateSupportService;
        }

        public PartialViewResult CreateWithoutModel()
        {   
            var  postFormModel = new PostFormModel();

            postFormModel.PostId = DateTime.Now.Ticks.ToString("X");

            return PartialView("Create", postFormModel);
        }

        public PartialViewResult Create(PostFormModel postFormModel)
        {
            return PartialView(postFormModel);
        }

        [HttpPost]
        public ActionResult Add(PostFormModel createPost)
        {
            Post post = Mapper.Map<PostFormModel, Post>(createPost);

            if (ModelState.IsValid)
            {
                postService.CreatePost(post);

                return RedirectToAction("Index","Home");
            }

            return View("Create", createPost);
        }

        public PartialViewResult ImageUpload(string postId, string postLongDesc, string postShortDesc)
        {
            UploadImageForPostViewModel imageVM = new UploadImageForPostViewModel();

            imageVM.PostId = postId;
            imageVM.PostLongDescription = !String.IsNullOrEmpty(postLongDesc) ? postLongDesc : String.Empty;
            imageVM.PostShortDescription = !String.IsNullOrEmpty(postShortDesc) ? postShortDesc : String.Empty;

            return PartialView(imageVM);
        }

        [HttpPost]
        public PartialViewResult UploadImage(UploadImageForPostViewModel model)
        {
            //Check if all simple data annotations are valid
            if (ModelState.IsValid)
            {
                //Prepare the needed variables
                Bitmap original = null;
                var name = "newimagefile";
                var errorField = string.Empty;

                if (model.IsUrl)
                {
                    errorField = "Url";
                    name = GetUrlFileName(model.Url);
                    original = GetImageFromUrl(model.Url);
                }
                else if (model.File != null)
                {
                    errorField = "File";
                    name = Path.GetFileNameWithoutExtension(model.File.FileName);
                    original = Bitmap.FromStream(model.File.InputStream) as Bitmap;
                }

                //If we had success so far
                if (original != null)
                {
                    var img = CreateImage(original, model.X, model.Y, model.Width, model.Height);
                    var fileName = model.PostId;
                    //var oldFilepath = userService.GetUser(User.Identity.GetUserId()).ProfilePicUrl;
                    //var oldFile = Server.MapPath(oldFilepath);
                    //Demo purposes only - save image in the file system
                    var fn = Server.MapPath("~/Content/Posts/Post_" + fileName + ".png");
                    img.Save(fn, System.Drawing.Imaging.ImageFormat.Png);
                    //postService.SaveImageURL(model.PostId, "~/Content/Posts/Post_" + fileName + ".png");
                    //if (System.IO.File.Exists(oldFile))
                    //{
                    //    System.IO.File.Delete(oldFile);
                    //}
                    model.PostPictureUrl = fn;
                    //return RedirectToAction("UserProfile", new { id = User.Identity.GetUserId() });
                }
                else //Otherwise we add an error and return to the (previous) view with the model data
                    ModelState.AddModelError(errorField, Resources.UploadError);
            }

            var postModel = new PostFormModel();

            postModel.PostId = model.PostId;
            postModel.PostLongDescription = !String.IsNullOrEmpty(model.PostLongDescription)
                ? model.PostLongDescription
                : String.Empty;
            postModel.PostShortDescription = !String.IsNullOrEmpty(model.PostShortDescription)
                ? model.PostShortDescription
                : String.Empty;
            postModel.PostPictureUrl = !String.IsNullOrEmpty(model.PostPictureUrl)
                ? model.PostPictureUrl
                : String.Empty;
            postModel.UserId = User.Identity.GetUserId();

            // return PartialView("Create", postModel);
            return PartialView("Create", postModel);
        }

        //[HttpPost]
        //public PartialViewResult UploadImage(string url, bool isUrl, HttpPostedFile File, string LocalPath, bool IsFile, int X, int Y, int Width, int Height, string PostId, string PostShortDescription, string PostLongDescription, string PostPictureUrl)
        //{
        //    //Check if all simple data annotations are valid
        //    if (ModelState.IsValid)
        //    {
        //        //Prepare the needed variables
        //        Bitmap original = null;
        //        var name = "newimagefile";
        //        var errorField = string.Empty;

        //        if (isUrl)
        //        {
        //            errorField = "Url";
        //            name = GetUrlFileName(url);
        //            original = GetImageFromUrl(url);
        //        }
        //        else if (File != null)
        //        {
        //            errorField = "File";
        //            name = Path.GetFileNameWithoutExtension(File.FileName);
        //            original = Bitmap.FromStream(File.InputStream) as Bitmap;
        //        }

        //        //If we had success so far
        //        if (original != null)
        //        {
        //            var img = CreateImage(original, X, Y, Width, Height);
        //            var fileName = PostId;
        //            //var oldFilepath = userService.GetUser(User.Identity.GetUserId()).ProfilePicUrl;
        //            //var oldFile = Server.MapPath(oldFilepath);
        //            //Demo purposes only - save image in the file system
        //            var fn = Server.MapPath("~/Content/Posts/Post_" + fileName + ".png");
        //            img.Save(fn, System.Drawing.Imaging.ImageFormat.Png);
        //            //postService.SaveImageURL(model.PostId, "~/Content/Posts/Post_" + fileName + ".png");
        //            //if (System.IO.File.Exists(oldFile))
        //            //{
        //            //    System.IO.File.Delete(oldFile);
        //            //}
        //            PostPictureUrl = fn;
        //            //return RedirectToAction("UserProfile", new { id = User.Identity.GetUserId() });
        //        }
        //        else //Otherwise we add an error and return to the (previous) view with the model data
        //            ModelState.AddModelError(errorField, Resources.UploadError);
        //    }

        //    var postModel = new PostFormModel();

        //    postModel.PostId = PostId;
        //    postModel.PostLongDescription = !String.IsNullOrEmpty(PostLongDescription)
        //        ? PostLongDescription
        //        : String.Empty;
        //    postModel.PostShortDescription = !String.IsNullOrEmpty(PostShortDescription)
        //        ? PostShortDescription
        //        : String.Empty;
        //    postModel.PostPictureUrl = !String.IsNullOrEmpty(PostPictureUrl)
        //        ? PostPictureUrl
        //        : String.Empty;
        //    postModel.UserId = User.Identity.GetUserId();

        //    // return PartialView("Create", postModel);
        //    return PartialView("Create", postModel);
        //}

        /// <summary>
        /// Gets an image from the specified URL.
        /// </summary>
        /// <param name="url">The URL containing an image.</param>
        /// <returns>The image as a bitmap.</returns>
        Bitmap GetImageFromUrl(string url)
        {
            var buffer = 1024;
            Bitmap image = null;

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                return image;

            using (var ms = new MemoryStream())
            {
                var req = WebRequest.Create(url);

                using (var resp = req.GetResponse())
                {
                    using (var stream = resp.GetResponseStream())
                    {
                        var bytes = new byte[buffer];
                        var n = 0;

                        while ((n = stream.Read(bytes, 0, buffer)) != 0)
                            ms.Write(bytes, 0, n);
                    }
                }

                image = Bitmap.FromStream(ms) as Bitmap;
            }

            return image;
        }

        /// <summary>
        /// Gets the filename that is placed under a certain URL.
        /// </summary>
        /// <param name="url">The URL which should be investigated for a file name.</param>
        /// <returns>The file name.</returns>
        string GetUrlFileName(string url)
        {
            var parts = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var last = parts[parts.Length - 1];
            return Path.GetFileNameWithoutExtension(last);
        }

        /// <summary>
        /// Creates a small image out of a larger image.
        /// </summary>
        /// <param name="original">The original image which should be cropped (will remain untouched).</param>
        /// <param name="x">The value where to start on the x axis.</param>
        /// <param name="y">The value where to start on the y axis.</param>
        /// <param name="width">The width of the final image.</param>
        /// <param name="height">The height of the final image.</param>
        /// <returns>The cropped image.</returns>
        Bitmap CreateImage(Bitmap original, int x, int y, int width, int height)
        {
            var img = new Bitmap(width, height);

            using (var g = Graphics.FromImage(img))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, new Rectangle(0, 0, width, height), x, y, width, height, GraphicsUnit.Pixel);
            }

            return img;
        }
	}
}