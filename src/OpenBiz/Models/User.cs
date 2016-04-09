using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace OpenBiz.Models
{
    public class User:IdentityUser
    {
        public DateTime DateCreated { get; set; }
    }
}