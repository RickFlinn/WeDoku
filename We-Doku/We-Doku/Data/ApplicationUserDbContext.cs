using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using We_Doku.Models;

namespace We_Doku.Data
{
    public class ApplicationUserDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// This method setup up our application database
        /// </summary>
        /// <param name="options">Application User Db</param>
        public ApplicationUserDbContext(DbContextOptions<ApplicationUserDbContext> options) : base(options)
        {

        }
    }
}
