using HouseholdManager.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseholdManager.Data;

public class HouseholdManagerContext : IdentityDbContext<HouseholdManagerUser>
{
    public HouseholdManagerContext(DbContextOptions<HouseholdManagerContext> options)
        : base(options)
    {
    }

    public HouseholdManagerContext(DbContextOptions options) : base(options)
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
