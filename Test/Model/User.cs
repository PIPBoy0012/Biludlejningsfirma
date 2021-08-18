using System;
using System.Collections.Generic;

#nullable disable

namespace Test.Model
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserGroup { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
