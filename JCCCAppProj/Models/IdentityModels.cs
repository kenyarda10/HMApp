using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JCCCAppProj.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber2 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string userRoleName) : base(userRoleName) { }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ProjectConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<RoleViewModel> RoleViewModels { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyLogo> CompanyLogos { get; set; }
        public DbSet<EducationDetail> EducationDetails { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<JobApplicationStatus> JobApplicationStatuses { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        


    }
}