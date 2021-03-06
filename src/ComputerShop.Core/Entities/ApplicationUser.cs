﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ComputerShop.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string ProfileImage { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<UserBasket> UserBasket { get; set; }
        public virtual ICollection<UserDevice> UserDevice { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}