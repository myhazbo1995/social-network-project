using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace SocialNetwork.Web.ViewModels
{
    public class PostFormModel
    {
        public string PostId { get; set; }

        [Required(ErrorMessage = "*")]
        public string PostShortDescription { set; get; }

        [Required(ErrorMessage = "*")]
        public string PostLongDescription { get; set; }

        [Required(ErrorMessage = "*")]
        public string PostPictureUrl { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string UserId { get; set; }
    }
    
}