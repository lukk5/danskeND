using danskeND.Repository.Entity;
using danskeND.Repository.Entity.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace danskeND.Repository.Context;

public class DbContext : IdentityDbContext
{
    private IHttpContextAccessor _httpContextAccessor;

    public DbSet<SortEntity> SortEntities { get; init; }
    public DbSet<MeasureResultEntity> MeasureResultEntities { get; set; }

    public DbContext()
    {
    }

    public DbContext(DbContextOptions<DbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) // settina auditable ir base propercius
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is AuditableEntity && e.State is EntityState.Added or EntityState.Modified);

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                ((AuditableEntity)entityEntry.Entity).CreatedBy =
                    this._httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "system";
                //(AuditableEntity)entityEntry.Entity).Id = Guid.NewGuid();
            }
            else
            {
                Entry((AuditableEntity)entityEntry.Entity).Property(p => p.LastUpdatedAt).IsModified = false;
                Entry((AuditableEntity)entityEntry.Entity).Property(p => p.LastUpdatedBy).IsModified = false;
            }

            ((AuditableEntity)entityEntry.Entity).LastUpdatedAt = DateTime.UtcNow;
            ((AuditableEntity)entityEntry.Entity).LastUpdatedBy =
                _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "system";
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}