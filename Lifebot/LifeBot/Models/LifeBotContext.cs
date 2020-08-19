using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LifeBot.Models
{
    public partial class LifeBotContext : DbContext
    {
        public LifeBotContext()
        {
        }

        public LifeBotContext(DbContextOptions<LifeBotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Config> Config { get; set; }
        public virtual DbSet<CostTypes> CostTypes { get; set; }
        public virtual DbSet<GroupMembers> GroupMembers { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<TaskCosts> TaskCosts { get; set; }
        public virtual DbSet<TaskGroups> TaskGroups { get; set; }
        public virtual DbSet<TaskTypes> TaskTypes { get; set; }
        public virtual DbSet<TaskUsers> TaskUsers { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TxtAccounts> TxtAccounts { get; set; }
        public virtual DbSet<TxtProviders> TxtProviders { get; set; }
        public virtual DbSet<Urgencies> Urgencies { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=D:\\\\\\\\LifeBot.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Config>(entity =>
            {
                entity.HasKey(e => e.ConfId);

                entity.ToTable("config");

                entity.HasIndex(e => e.ConfId)
                    .IsUnique();

                entity.HasIndex(e => e.ConfName)
                    .IsUnique();

                entity.Property(e => e.ConfId)
                    .HasColumnName("conf_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConfName)
                    .IsRequired()
                    .HasColumnName("conf_name");

                entity.Property(e => e.ConfType)
                    .IsRequired()
                    .HasColumnName("conf_type");

                entity.Property(e => e.ConfValue).HasColumnName("conf_value");
            });

            modelBuilder.Entity<CostTypes>(entity =>
            {
                entity.HasKey(e => e.CostTypeId);

                entity.ToTable("cost_types");

                entity.HasIndex(e => e.CostName)
                    .IsUnique();

                entity.HasIndex(e => e.CostTypeId)
                    .IsUnique();

                entity.Property(e => e.CostTypeId)
                    .HasColumnName("cost_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CostName)
                    .IsRequired()
                    .HasColumnName("cost_name");
            });

            modelBuilder.Entity<GroupMembers>(entity =>
            {
                entity.HasKey(e => e.GrpMemberId);

                entity.ToTable("group_members");

                entity.HasIndex(e => e.GrpMemberId)
                    .IsUnique();

                entity.Property(e => e.GrpMemberId)
                    .HasColumnName("grp_member_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.GrpMemberLabel)
                    .IsRequired()
                    .HasColumnName("grp_member_label");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("groups");

                entity.HasIndex(e => e.GroupId)
                    .IsUnique();

                entity.Property(e => e.GroupId)
                    .HasColumnName("group_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GroupChannel).HasColumnName("group_channel");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("group_name");

                entity.Property(e => e.GroupOwnerId).HasColumnName("group_owner_id");

                entity.Property(e => e.GroupProviderId).HasColumnName("group_provider_id");

                entity.HasOne(d => d.GroupOwner)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.GroupOwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TaskCosts>(entity =>
            {
                entity.HasKey(e => e.CostId);

                entity.ToTable("task_costs");

                entity.HasIndex(e => e.CostId)
                    .IsUnique();

                entity.Property(e => e.CostId)
                    .HasColumnName("cost_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CostAmount)
                    .IsRequired()
                    .HasColumnName("cost_amount")
                    .HasColumnType("NUMERIC")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CostTypeId).HasColumnName("cost_type_id");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.HasOne(d => d.CostType)
                    .WithMany(p => p.TaskCosts)
                    .HasForeignKey(d => d.CostTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskCosts)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TaskGroups>(entity =>
            {
                entity.HasKey(e => new { e.TaskId, e.GroupId });

                entity.ToTable("task_groups");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TaskGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskGroups)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TaskTypes>(entity =>
            {
                entity.HasKey(e => e.TaskTypeId);

                entity.ToTable("task_types");

                entity.HasIndex(e => e.TaskTypeId)
                    .IsUnique();

                entity.HasIndex(e => e.TaskTypeName)
                    .IsUnique();

                entity.Property(e => e.TaskTypeId)
                    .HasColumnName("task_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TaskTypeName)
                    .IsRequired()
                    .HasColumnName("task_type_name");
            });

            modelBuilder.Entity<TaskUsers>(entity =>
            {
                entity.HasKey(e => new { e.TaskId, e.UserId });

                entity.ToTable("task_users");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskUsers)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TaskUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.ToTable("tasks");

                entity.HasIndex(e => e.TaskId)
                    .IsUnique();

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DueDate).HasColumnName("due_date");

                entity.Property(e => e.LastDone).HasColumnName("last_done");

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasColumnName("task_name");

                entity.Property(e => e.TaskTypeId)
                    .HasColumnName("task_type_id")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UrgencyId).HasColumnName("urgency_id");

                entity.HasOne(d => d.TaskType)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Urgency)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.UrgencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TxtAccounts>(entity =>
            {
                entity.HasKey(e => e.TxtAcctId);

                entity.ToTable("txt_accounts");

                entity.HasIndex(e => e.TxtAcctId)
                    .IsUnique();

                entity.HasIndex(e => new { e.TxtProviderId, e.TxtChannel })
                    .IsUnique();

                entity.Property(e => e.TxtAcctId)
                    .HasColumnName("txt_acct_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TxtAcctName)
                    .IsRequired()
                    .HasColumnName("txt_acct_name");

                entity.Property(e => e.TxtChannel).HasColumnName("txt_channel");

                entity.Property(e => e.TxtProviderId).HasColumnName("txt_provider_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.TxtProvider)
                    .WithMany(p => p.TxtAccounts)
                    .HasForeignKey(d => d.TxtProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TxtAccounts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TxtProviders>(entity =>
            {
                entity.HasKey(e => e.TxtProviderId);

                entity.ToTable("txt_providers");

                entity.HasIndex(e => e.TxtProviderId)
                    .IsUnique();

                entity.Property(e => e.TxtProviderId)
                    .HasColumnName("txt_provider_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TxtProviderName)
                    .IsRequired()
                    .HasColumnName("txt_provider_name");
            });

            modelBuilder.Entity<Urgencies>(entity =>
            {
                entity.HasKey(e => e.UrgencyId);

                entity.ToTable("urgencies");

                entity.HasIndex(e => e.UrgencyId)
                    .IsUnique();

                entity.HasIndex(e => e.UrgencyName)
                    .IsUnique();

                entity.Property(e => e.UrgencyId)
                    .HasColumnName("urgency_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.UrgencyDesc).HasColumnName("urgency_desc");

                entity.Property(e => e.UrgencyName)
                    .IsRequired()
                    .HasColumnName("urgency_name");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users");

                entity.HasIndex(e => e.UserId)
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserFamily).HasColumnName("user_family");

                entity.Property(e => e.UserGiven).HasColumnName("user_given");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
