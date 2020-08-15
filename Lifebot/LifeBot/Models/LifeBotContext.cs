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
        public virtual DbSet<GroupMembers> GroupMembers { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<TxtAccounts> TxtAccounts { get; set; }
        public virtual DbSet<TxtProviders> TxtProviders { get; set; }
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

            modelBuilder.Entity<TxtAccounts>(entity =>
            {
                entity.HasKey(e => e.TxtAcctId);

                entity.ToTable("txt_accounts");

                entity.HasIndex(e => e.TxtAcctId)
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
