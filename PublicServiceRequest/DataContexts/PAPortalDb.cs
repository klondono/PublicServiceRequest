namespace CustomerService_PSR.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Utilities;

    public partial class PAPortalDb : BaseDbContext
    {
        public PAPortalDb()
            :base("name=PAPortalDb")
        {
        }

        public virtual DbSet<SystemSetting> SystemSettings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemSetting>()
                .Property(e => e.SystemSettingName)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetting>()
                .Property(e => e.SystemSettingCategory)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetting>()
                .Property(e => e.SystemSettingValue)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetting>()
                .Property(e => e.SystemSettingUse)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetting>()
                .Property(e => e.SystemSettingLookupKey)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetting>()
                .Property(e => e.SystemSettingLookupValue)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetting>()
                .Property(e => e.SystemSettingApplicationName)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetting>()
                .Property(e => e.SystemSettingParameter)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetting>()
                .Property(e => e.SystemSettingGroup)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetting>()
                .Property(e => e.SystemSettingMessage)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetting>()
                .Property(e => e.SystemSettingLabel)
                .IsUnicode(false);
        }

        public SystemSetting GetSystemSetting(string strSystemSettingName)
        {
            return SystemSettings.Where(x => x.SystemSettingName == strSystemSettingName && (DateTime.Now >= (x.SystemBeginDate == null ? DateTime.MinValue : x.SystemBeginDate)) && (DateTime.Now <= (x.SystemEndDate == null ? DateTime.MaxValue : x.SystemEndDate))).FirstOrDefault();
             
        }

    }
}
