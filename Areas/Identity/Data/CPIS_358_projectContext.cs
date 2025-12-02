using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CPIS_358_project.Models;
namespace CPIS_358_project.Areas.Identity.Data;

public class CPIS_358_projectContext : IdentityDbContext<User>
{
    public CPIS_358_projectContext(DbContextOptions<CPIS_358_projectContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
