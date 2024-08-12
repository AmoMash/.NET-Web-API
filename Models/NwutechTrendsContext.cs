using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TelemetryAPI_3420.Models;

public partial class NwutechTrendsContext : DbContext
{
    public NwutechTrendsContext()
    {
    }

    public NwutechTrendsContext(DbContextOptions<NwutechTrendsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<JobTelemetry> JobTelemetries { get; set; }

    public virtual DbSet<Process> Processes { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Client", "Configs");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.DateOnboarded).HasColumnType("datetime");
        });

        modelBuilder.Entity<JobTelemetry>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("JobTelemetry", "Tellemetry");

            entity.Property(e => e.AdditionalInfo).IsUnicode(false);
            entity.Property(e => e.BusinessFunction).IsUnicode(false);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.Geography).IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.JobId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("JobID");
            entity.Property(e => e.ProccesId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ProccesID");
            entity.Property(e => e.QueueId)
                .IsUnicode(false)
                .HasColumnName("QueueID");
            entity.Property(e => e.StepDescription).IsUnicode(false);
            entity.Property(e => e.UniqueReference).IsUnicode(false);
            entity.Property(e => e.UniqueReferenceType).IsUnicode(false);
        });

        modelBuilder.Entity<Process>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Process", "Configs");

            entity.Property(e => e.DateSubmitted).HasColumnType("datetime");
            entity.Property(e => e.DefaultBusinessFunction)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DefaultGeography)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Platform)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProcessConfigUrl)
                .IsUnicode(false)
                .HasColumnName("ProcessConfigURL");
            entity.Property(e => e.ProcessId).HasColumnName("ProcessID");
            entity.Property(e => e.ProcessName).IsUnicode(false);
            entity.Property(e => e.ProcessType).IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ReportUrl)
                .IsUnicode(false)
                .HasColumnName("ReportURL");
            entity.Property(e => e.Submitter).IsUnicode(false);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Projects", "Configs");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.ProjectCreationDate).HasColumnType("datetime");
            entity.Property(e => e.ProjectDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProjectStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
