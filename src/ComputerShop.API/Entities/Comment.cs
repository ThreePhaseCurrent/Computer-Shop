using System;
using ComputerShop.API.Data;

namespace ComputerShop.API.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int? ParentId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}