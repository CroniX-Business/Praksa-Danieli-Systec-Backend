// <copyright file="EntitySaveChangesInterceptor.cs" company="Danieli Automation S.p.A.">
// Copyright (c) Danieli Automation S.p.A.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Automation S.p.A.
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

    /// <summary>
    /// Initializes a new instance of the <see cref="EntitySaveChangesInterceptor"/> class.
    /// </summary>
    /// <param name="userContextService">The user context service.</param>

    /// <inheritdoc />
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        this.UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    /// <inheritdoc />
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        this.UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static bool HasChangedOwnedEntities(EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry?.Metadata.IsOwned() == true
            && (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));

    private void UpdateEntities(DbContext? context)
    {
        if (context == null)
        {
            return;
        }

        foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.UtcNow;
                entry.Entity.ModifiedDate = null;
            }

            if (entry.State == EntityState.Modified || HasChangedOwnedEntities(entry))
            {
                entry.Property(x => x.CreatedDate).IsModified = false;

                entry.Entity.ModifiedDate = DateTime.UtcNow;
            }
        }
    }
}
