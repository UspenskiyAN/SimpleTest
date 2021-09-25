using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<Models.User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        private void beforeSave()
        {
            foreach (var user in this.ChangeTracker.Entries<Models.User>().Where(w => w.State == EntityState.Modified))
            {
                user.CurrentValues[nameof(Models.User.LastModifiedDate)] = DateTime.UtcNow;
            }
        }
        public override int SaveChanges()
        {
            beforeSave();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            beforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
