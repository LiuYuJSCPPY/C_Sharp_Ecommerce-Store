using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace EcommerceStore.Model
{
    [Table("AdminUser",Schema ="dbo")]
    public class AdminUser : IdentityUser
    {

        public string UserName { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string UserImagePath { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AdminUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual Order Order { get; set; }
        public virtual Cart Cart { get; set; }
    }
   
}
