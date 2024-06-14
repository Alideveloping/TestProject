using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Domain.Entity
{
    public class Role : IdentityRole
    {
        public string? DisplayName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public bool IsRemoved { get; set; }

    }
}
