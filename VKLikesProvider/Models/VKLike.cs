using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VKLikesProvider.Models
{
    public class VKLike
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public DateTime Moment { get; set; }
    }
}