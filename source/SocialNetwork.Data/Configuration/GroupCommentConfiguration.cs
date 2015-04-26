﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SocialNetwork.Model.Models;


namespace SocialNetwork.Data.Configuration
{
    public class GroupCommentConfiguration: EntityTypeConfiguration<GroupComment>
    {
        public GroupCommentConfiguration()
        {
            Property(g => g.GroupUpdateId).IsRequired();
            Property(g => g.CommentText).IsMaxLength();
            Property(g => g.CommentDate).IsRequired();
        }
    }
}
