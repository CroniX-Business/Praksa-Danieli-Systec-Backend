// <copyright file="EntitySaveChangesInterceptor.cs" company="Danieli Automation S.p.A.">
// Copyright (c) Danieli Automation S.p.A.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Automation S.p.A.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Q3Premium.ProblemSolving.Application.Common.Security;
using Q3Premium.ProblemSolving.Domain.Common.Entities;

namespace Q3Premium.ProblemSolving.Infrastructure.Interceptors;

/// <summary>
/// Entity save changes interceptor.
/// </summary>
/// <seealso cref="SaveChangesInterceptor" />
public class EntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly IUserContextService userContextService;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntitySaveChangesInterceptor"/> class.
    /// </summary>
    /// <param name="userContextService">The user context service.</param>
    public EntitySaveChangesInterceptor(IUserContextService userContextService)
    {
        this.userContextService = userContextService;
    }

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

        var user = this.userContextService.CurrentUser
            ?? throw new InvalidOperationException("Unable to save data without user information.");

        foreach (var entry in context.ChangeTracker.Entries<BaseEntity<int>>())
        {
            if (entry.State == EntityState.Added)
            {
                if (entry.Entity.Guid == Guid.Empty)
                {
                    entry.Entity.Guid = Guid.NewGuid();
                }

                entry.Entity.CreatedBy = user.Name;
                entry.Entity.CreatedById = user.UserId;
                entry.Entity.CreatedOn = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified || HasChangedOwnedEntities(entry))
            {
                entry.Property(x => x.Guid).IsModified = false;
                entry.Property(x => x.CreatedBy).IsModified = false;
                entry.Property(x => x.CreatedById).IsModified = false;
                entry.Property(x => x.CreatedOn).IsModified = false;

                entry.Entity.ModifiedBy = user.Name;
                entry.Entity.ModifiedById = user.UserId;
                entry.Entity.ModifiedOn = DateTime.UtcNow;
            }
        }
    }
}
