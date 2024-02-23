﻿// <copyright file="EntitySaveChangesInterceptor.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplication2.DTO;

namespace WebApplication2.Interceptors;

/// <summary>
/// Entity save changes interceptor.
/// </summary>
/// <seealso cref="SaveChangesInterceptor" />
public class EntitySaveChangesInterceptor : SaveChangesInterceptor
{
    /// <inheritdoc/>
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        this.UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    /// <inheritdoc/>
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

        foreach (var entry in context.ChangeTracker.Entries<BaseDTO>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
                entry.Property("ModifiedDate").CurrentValue = null; // Set ModifiedDate to null for newly created entities

                if (entry.State == EntityState.Modified || HasChangedOwnedEntities(entry))
                {
                    entry.Property("CreatedDate").IsModified = false; // Do not modify CreatedDate for modified entities

                    entry.Property("ModifiedDate").CurrentValue = DateTime.UtcNow;
                    entry.Property("ModifiedDate").IsModified = true; // Ensure ModifiedDate is marked as modified
                }
            }
        }
    }
}
