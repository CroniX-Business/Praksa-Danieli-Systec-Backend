// <copyright file="EntitySaveChangesInterceptor.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplication2.Entities;

namespace WebApplication2.Interceptors;

/// <summary>
/// Entity save changes interceptor.
/// </summary>
/// <seealso cref="SaveChangesInterceptor" />
public class EntitySaveChangesInterceptor : SaveChangesInterceptor
{
    /// <inheritdoc />
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        EntitySaveChangesInterceptor.UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    /// <inheritdoc />
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        EntitySaveChangesInterceptor.UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static bool HasChangedOwnedEntities(EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry?.Metadata.IsOwned() == true
            && (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));

    private static void UpdateEntities(DbContext? context)
    {
        if (context == null)
        {
            return;
        }

        foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.ModifiedDate = null;
                entry.Entity.CreatedDate = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified || HasChangedOwnedEntities(entry))
            {
                entry.Entity.ModifiedDate = DateTime.UtcNow;
                entry.Property(x => x.CreatedDate).IsModified = false;
            }
        }
    }
}
