﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SocialNetwork.Model.Models;

namespace SocialNetwork.Data.Configuration
{
    public class GroupUpdateSupportConfiguration:EntityTypeConfiguration<GroupUpdateSupport>
    {
        public GroupUpdateSupportConfiguration()
        {
            Property(g => g.GroupUpdateId).IsRequired();
            Property(g => g.GroupUserId).IsRequired();
            Property(g => g.UpdateSupportedDate).IsRequired();
        }
    }
}