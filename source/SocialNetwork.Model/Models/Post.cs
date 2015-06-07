using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SocialNetwork.Model.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string PostShortDescription { set; get; }

        public string PostLongDescription { get; set; }

        public string PostPictureUrl { get; set; }

        public string UserId { get; set; }

        public int Viewed { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<Comment> Comments { get; set; } 

        public Post()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
