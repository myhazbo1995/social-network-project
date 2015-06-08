using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Web.ViewModels
{
    public class UploadImageForPostViewModel
    {
        [Display(Name = "Internet URL")]
        public string Url { get; set; }

        public bool IsUrl { get; set; }
        
        [Display(Name = "Local file")]
        public HttpPostedFileBase File { get; set; }

        public string LocalPath { get; set; }

        public bool IsFile { get; set; }

        [Range(0, int.MaxValue)]
        public int X { get; set; }

        [Range(0, int.MaxValue)]
        public int Y { get; set; }

        [Range(1, int.MaxValue)]
        public int Width { get; set; }

        [Range(1, int.MaxValue)]
        public int Height { get; set; }

        public string PostId { get; set; }

        public string PostShortDescription { set; get; }

        public string PostLongDescription { get; set; }

        public string PostPictureUrl { get; set; }
    }
}