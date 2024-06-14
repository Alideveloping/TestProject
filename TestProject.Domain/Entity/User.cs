using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Common;
using Microsoft.AspNetCore.Identity;


namespace TestProject.Domain.Entity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public int Age { get; set; }
        public string Address { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}
