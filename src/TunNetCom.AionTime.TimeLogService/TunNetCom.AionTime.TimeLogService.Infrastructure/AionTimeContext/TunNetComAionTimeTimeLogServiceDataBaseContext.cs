﻿namespace TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext;

public partial class TunNetComAionTimeTimeLogServiceDataBaseContext : DbContext
{
    public TunNetComAionTimeTimeLogServiceDataBaseContext(DbContextOptions<TunNetComAionTimeTimeLogServiceDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Organisation> Organisations { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<WorkItem> WorkItems { get; set; }

    public virtual DbSet<WorkItemHistory> WorkItemHistories { get; set; }

    public virtual DbSet<WorkItemTimeLog> WorkItemTimeLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.OrganisationConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.WorkItemConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.WorkItemHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.WorkItemTimeLogConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
