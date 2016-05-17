using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VKLikesProvider.Models
{
    public class LikesDBContext:DbContext
    {
        public LikesDBContext():base("DbConnection"){ }

        public DbSet<VKLike> VKLikes { get; set; }
    }
}