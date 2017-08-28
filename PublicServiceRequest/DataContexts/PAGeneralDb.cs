namespace CustomerService_PSR.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using Utilities;

    public partial class PAGeneralDb : BaseDbContext
    {
        public PAGeneralDb()
            : base("name=PAGeneralDb")
        {
            //Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public virtual DbSet<AttachmentType> AttachmentTypes { get; set; }
        public virtual DbSet<ApplicationSource> ApplicationSources { get; set; }
        public virtual DbSet<CustomFieldDataType> CustomFieldDataTypes { get; set; }
        public virtual DbSet<CustomFieldSelectListItem> CustomFieldSelectListItems { get; set; }
        public virtual DbSet<CustomFieldType> CustomFieldTypes { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestAction> RequestActions { get; set; }
        public virtual DbSet<RequestActionCustomFieldTransaction> RequestActionCustomFieldTransactions { get; set; }
        public virtual DbSet<RequestActionType> RequestActionTypes { get; set; }
        public virtual DbSet<RequestActionTypeCustomField> RequestActionTypeCustomFields { get; set; }
        public virtual DbSet<RequestAttachment> RequestAttachments { get; set; }
        public virtual DbSet<RequestFolio> RequestFolios { get; set; }
        public virtual DbSet<RequestAgenda> RequestAgendas { get; set; }
        public virtual DbSet<RequestFolioType> RequestFolioTypes { get; set; }
        public virtual DbSet<RequestOrigin> RequestOrigins { get; set; }
        public virtual DbSet<RequestPriority> RequestPriorities { get; set; }
        public virtual DbSet<RequestStatus> RequestStatuses { get; set; }
        public virtual DbSet<RequestTaxpayer> RequestTaxpayers { get; set; }
        public virtual DbSet<RequestTaxpayerPreferredLanguage> RequestTaxpayerPreferredLanguages { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<ServiceTypeChildStartTrigger> ServiceTypeChildStartTriggers { get; set; }
        public virtual DbSet<ServiceTypeCustomField> ServiceTypeCustomFields { get; set; }
        public virtual DbSet<ServiceTypeCustomFieldTransaction> ServiceTypeCustomFieldTransactions { get; set; }
        public virtual DbSet<ServiceTypeOwnerGroup> ServiceTypeOwnerGroups { get; set; }
        public virtual DbSet<ServiceTypeOwnerGroupLocation> ServiceTypeOwnerGroupLocations { get; set; }
        public virtual DbSet<ServiceTypeOwnerGroupMember> ServiceTypeOwnerGroupMembers { get; set; }
        public virtual DbSet<ServiceTypeRelationshipDefinition> ServiceTypeRelationshipDefinitions { get; set; }
        public virtual DbSet<ServiceTypeRequestActionTypeLink> ServiceTypeRequestActionTypeLinks { get; set; }
        public virtual DbSet<ServiceTypeResolution> ServiceTypeResolutions { get; set; }
        public virtual DbSet<ServiceTypeResolutionLink> ServiceTypeResolutionLinks { get; set; }
        public virtual DbSet<ServiceTypeSearchKeyword> ServiceTypeSearchKeywords { get; set; }
        public virtual DbSet<ServiceTypeSearchKeywordLink> ServiceTypeSearchKeywordLinks { get; set; }
        public virtual DbSet<RequestQueue> RequestQueues { get; set; }
        //Views:
        public virtual DbSet<View_PersonalPropertyData> View_PersonalPropertyData { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<View_RequestMainSearchGridWFolio> View_RequestMainSearchGridWFolio { get; set; }
        public virtual DbSet<View_RequestFolioByRequestNumberAndYear> View_RequestFolioByRequestNumberAndYear { get; set; }
        public virtual DbSet<View_RequestFolioGrid> View_RequestFolioGrid { get; set; }
        public virtual DbSet<View_PSRAdmUserAdded> View_PSRAdmUserAdded { get; set; }
        public virtual DbSet<View_PSRCurrentlyAssigned> View_PSRCurrentlyAssigned { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationSource>()
                .Property(e => e.ApplicationSourceName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationSource>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationSource>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationSource>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationSource>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationSource>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AttachmentTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AttachmentDescription)
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<AttachmentType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.CustomFieldDataTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.CustomFieldDataTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.RegularExpression)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.ErrorMessage)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldDataType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.CustomFieldSelectListItemLabel)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.CustomFieldSelectListItemValue)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldSelectListItem>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.CustomFieldTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.CustomFieldTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomFieldType>()
                .HasMany(e => e.CustomFieldSelectListItems)
                .WithRequired(e => e.CustomFieldType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.RequestCurrentWorkerFullName)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.RequestNumber)
                .IsUnicode(false);

            //modelBuilder.Entity<Request>()
            //    .Property(e => e.RequestSuffix)
            //    .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.FormattedRequestNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.RequestComments)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.RequestUpdateNotificationEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .HasMany(e => e.ServiceTypeCustomFieldTransactions)
                .WithRequired(e => e.Request)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestAction>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<RequestAction>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestAction>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestAction>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestAction>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestAction>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestAction>()
                .HasMany(e => e.RequestActionCustomFieldTransactions)
                .WithRequired(e => e.RequestAction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestActionCustomFieldTransaction>()
                .Property(e => e.DisplayData)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionCustomFieldTransaction>()
                .Property(e => e.FieldValue)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionCustomFieldTransaction>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionCustomFieldTransaction>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionCustomFieldTransaction>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionCustomFieldTransaction>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionCustomFieldTransaction>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.RequestActionTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.RequestActionTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.BackgroundColor)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.TextColor)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            //modelBuilder.Entity<RequestActionType>()
            //    .HasMany(e => e.ServiceTypeCustomFieldTransactions)
            //    .WithRequired(e => e.RequestActionType)
            //    .HasForeignKey(e => e.RequestID)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestActionType>()
                .HasMany(e => e.ServiceTypeRequestActionTypeLinks)
                .WithRequired(e => e.RequestActionType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.LabelName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.PlaceholderText)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.TextAlignment)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.TooltipMessage)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.GroupingIdentifier1)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.GroupingIdentifier2)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestActionTypeCustomField>()
                .HasMany(e => e.RequestActionCustomFieldTransactions)
                .WithRequired(e => e.RequestActionTypeCustomField)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestAttachment>()
                .Property(e => e.RequestAttachmentComment)
                .IsUnicode(false);

            modelBuilder.Entity<RequestAttachment>()
                .Property(e => e.RequestAttachmentName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestAttachment>()
            .Property(e => e.RequestAttachmentFriendlyName)
            .IsUnicode(false);

            modelBuilder.Entity<RequestAttachment>()
                .Property(e => e.FileExtension)
                .IsUnicode(false);

            modelBuilder.Entity<RequestAttachment>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestAttachment>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestAttachment>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestAttachment>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestAttachment>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                 .Property(e => e.Folio)
                 .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                 .Property(e => e.FormattedFolio)
                 .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                .Property(e => e.DORCode)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                .Property(e => e.Owner)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                .Property(e => e.SiteAddress)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                .Property(e => e.SiteCity)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                .Property(e => e.MailingAddress)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                .Property(e => e.MailingCity)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                .Property(e => e.MailingZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolio>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.RequestFolioTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.RequestFoliotypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestFolioType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.RequestOriginName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.RequestOriginDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.AutoSelectedForActiveDirectoryGroup)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestOrigin>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.RequestPriorityName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.RequestPriorityDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestPriority>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.RequestStatusName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.RequestStatusDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.RequestStatusColor)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestStatus>()
                .HasMany(e => e.RequestActions)
                .WithOptional(e => e.RequestStatus)
                .HasForeignKey(e => e.RequestStatusChangedID);

            modelBuilder.Entity<RequestStatus>()
                .HasMany(e => e.Requests)
                .WithOptional(e => e.RequestStatus)
                .HasForeignKey(e => e.RequestStatusID);

            modelBuilder.Entity<RequestStatus>()
                .HasMany(e => e.Requests__EscalationExpectedStatus)
                .WithOptional(e => e.EscalationExpectedStatusForServiceType)
                .HasForeignKey(e => e.RequestEscalationExpectedStatusID);

            modelBuilder.Entity<RequestStatus>()
                .HasMany(e => e.ServiceTypes_DefaultRequestStatus)
                .WithOptional(e => e.DefaultRequestStatusForServiceType)
                .HasForeignKey(e => e.DefaultRequestStatusID);

            modelBuilder.Entity<RequestStatus>()
                .HasMany(e => e.ServiceTypes_EscalationExpectedStatus)
                .WithOptional(e => e.EscalationExpectedStatusForServiceType)
                .HasForeignKey(e => e.EscalationExpectedStatusID);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.FirstName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.MiddleInitial)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.LastName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.FormattedTaxpayerName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.PhoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.PhoneNoType)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.AltPhoneNo1)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.AltPhoneNo1Type)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.AltPhoneNo2)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.AltPhoneNo2Type)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.FormattedPhoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.FormattedAltPhoneNo1)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.FormattedAltPhoneNo2)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.AltEmail)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayer>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
               .Property(e => e.RequestTaxpayerPreferredLanguageName)
               .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
                .Property(e => e.RequestTaxpayerPreferredLanguageDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestTaxpayerPreferredLanguage>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.RequestTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.RequestTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.ServiceTypeOwnerGroupOverrideMonthDayFrom)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.ServiceTypeOwnerGroupOverrideMonthDayTo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.ServiceTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.ServiceTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.ServiceTypeAvailableToActiveDirectoryGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceType>()
                .HasMany(e => e.AttachmentTypes)
                .WithRequired(e => e.ServiceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceType>()
                .HasMany(e => e.ServiceTypeRelationshipDefinitions)
                .WithOptional(e => e.ServiceType)
                .HasForeignKey(e => e.ServiceTypeParentID);

            modelBuilder.Entity<ServiceType>()
                .HasMany(e => e.ServiceTypeRelationshipDefinitions1)
                .WithOptional(e => e.ServiceType1)
                .HasForeignKey(e => e.ServiceTypeChildID);

            modelBuilder.Entity<ServiceType>()
                .HasMany(e => e.ServiceTypeRequestActionTypeLinks)
                .WithRequired(e => e.ServiceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceTypeChildStartTrigger>()
                .Property(e => e.ServiceTypeChildStartTriggerName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeChildStartTrigger>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeChildStartTrigger>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeChildStartTrigger>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeChildStartTrigger>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeChildStartTrigger>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeChildStartTrigger>()
                .HasMany(e => e.Requests)
                .WithOptional(e => e.ServiceTypeChildStartTrigger)
                .HasForeignKey(e => e.RequestStartTrigger);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.LabelName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.PlaceholderText)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.TextAlignment)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.TooltipMessage)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.GroupingIdentifier1)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.GroupingIdentifier2)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomField>()
                .HasMany(e => e.ServiceTypeCustomFieldTransactions)
                .WithRequired(e => e.ServiceTypeCustomField)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceTypeCustomFieldTransaction>()
                .Property(e => e.DisplayData)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomFieldTransaction>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomFieldTransaction>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomFieldTransaction>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomFieldTransaction>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomFieldTransaction>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeCustomFieldTransaction>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerGroupDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerAvailableToActiveDirectoryGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerActiveDirectoryGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerGroupMainEmail)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerGroupNotificationEmail)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerGroupEscalationEmail)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.ServiceTypeOwnerGroupPhoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .HasMany(e => e.Requests)
                .WithOptional(e => e.ServiceTypeOwnerGroup)
                .HasForeignKey(e => e.RequestCurrentOwnerGroupID);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .HasMany(e => e.RequestActions)
                .WithOptional(e => e.ServiceTypeOwnerGroup)
                .HasForeignKey(e => e.AssignedOwnerGroupID);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .HasMany(e => e.ServiceTypes)
                .WithOptional(e => e.ServiceTypeOwnerGroup)
                .HasForeignKey(e => e.ServiceTypeOwnerGroupID);

            modelBuilder.Entity<ServiceTypeOwnerGroup>()
                .HasMany(e => e.ServiceTypesForOverridingOwnerGroup)
                .WithOptional(e => e.OverridingServiceTypeOwnerGroup)
                .HasForeignKey(e => e.ServiceTypeOwnerGroupOverrideID);

            modelBuilder.Entity<ServiceTypeOwnerGroupLocation>()
                .Property(e => e.ServiceTypeOwnerGroupLocationName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupLocation>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupLocation>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupLocation>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupLocation>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupLocation>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupMember>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupMember>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupMember>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupMember>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeOwnerGroupMember>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRelationshipDefinition>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRelationshipDefinition>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRelationshipDefinition>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRelationshipDefinition>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRelationshipDefinition>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.AddActionActiveDirectoryGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.PrecedenceConstraintRequestActionTypeIDValue)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.UpdateActionActiveDirectoryGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.DeleteActionActiveDirectoryGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeRequestActionTypeLink>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeResolution>()
                .Property(e => e.ServiceTypeResolutionName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeResolution>()
                .Property(e => e.ServiceTypeResolutionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeResolution>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeResolution>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeResolution>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeResolution>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeResolution>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeResolution>()
                .HasMany(e => e.Requests)
                .WithOptional(e => e.ServiceTypeResolution)
                .HasForeignKey(e => e.RequestResolutionID);

            modelBuilder.Entity<ServiceTypeResolutionLink>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeResolutionLink>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeResolutionLink>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeResolutionLink>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeResolutionLink>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeyword>()
                .Property(e => e.ServiceTypeSearchKeywordName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeyword>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeyword>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeyword>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeyword>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeyword>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeywordLink>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeywordLink>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeywordLink>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeywordLink>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceTypeSearchKeywordLink>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestQueue>()
                .Property(e => e.RequestNumber)
                .IsUnicode(false);

            modelBuilder.Entity<RequestQueue>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequestQueue>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestQueue>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestQueue>()
                .Property(e => e.AdmUserAddedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestQueue>()
                .Property(e => e.AdmUserModifiedDomainName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestQueue>()
                .Property(e => e.RequestComments)
                .IsUnicode(false);

            modelBuilder.Entity<RequestQueue>()
                .Property(e => e.RequestCurrentWorkerFullName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestQueue>()
                .Property(e => e.RequestUpdateNotificationEmail)
                .IsUnicode(false);

            modelBuilder.Entity<View_PersonalPropertyData>()
                .Property(e => e.Folio)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<View_PersonalPropertyData>()
                .Property(e => e.FormattedFolio)
                .IsUnicode(false);

            modelBuilder.Entity<View_PersonalPropertyData>()
                .Property(e => e.Year)
                .HasPrecision(8, 0);

            modelBuilder.Entity<View_PersonalPropertyData>()
                .Property(e => e.Owner)
                .IsUnicode(false);

            modelBuilder.Entity<View_PersonalPropertyData>()
                .Property(e => e.SiteAddress)
                .IsUnicode(false);

            modelBuilder.Entity<View_PersonalPropertyData>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<View_PersonalPropertyData>()
                .Property(e => e.MailingAddress)
                .IsUnicode(false);

            modelBuilder.Entity<View_PersonalPropertyData>()
                .Property(e => e.MailingCity)
                .IsUnicode(false);

            modelBuilder.Entity<View_PersonalPropertyData>()
                .Property(e => e.MailingZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestMainSearchGridWFolio>()
             .Property(e => e.RequestNumber)
             .IsUnicode(false);

            modelBuilder.Entity<View_RequestMainSearchGridWFolio>()
                .Property(e => e.FormattedRequestNumber)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestMainSearchGridWFolio>()
                .Property(e => e.ServiceTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestMainSearchGridWFolio>()
                .Property(e => e.RequestStatusName)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestMainSearchGridWFolio>()
                .Property(e => e.RequestStatusColor)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestMainSearchGridWFolio>()
                .Property(e => e.RequestPriorityName)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestMainSearchGridWFolio>()
                .Property(e => e.Requestor)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestMainSearchGridWFolio>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestMainSearchGridWFolio>()
                .Property(e => e.CurrentlyAssigned)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestMainSearchGridWFolio>()
                .Property(e => e.Folio)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioByRequestNumberAndYear>()
                .Property(e => e.RequestFolioTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioByRequestNumberAndYear>()
                .Property(e => e.Folio)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioByRequestNumberAndYear>()
                .Property(e => e.FormattedFolio)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioByRequestNumberAndYear>()
                .Property(e => e.DORCode)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioByRequestNumberAndYear>()
                .Property(e => e.Owner)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioByRequestNumberAndYear>()
                .Property(e => e.SiteAddress)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioByRequestNumberAndYear>()
                .Property(e => e.SiteCity)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioByRequestNumberAndYear>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioByRequestNumberAndYear>()
                .Property(e => e.MailingAddress)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioByRequestNumberAndYear>()
                .Property(e => e.MailingCity)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioByRequestNumberAndYear>()
                .Property(e => e.MailingZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioByRequestNumberAndYear>()
                .Property(e => e.RequestNumber)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.Folio)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.FormattedFolio)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.DORCode)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.Owner)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.SiteAddress)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.SiteCity)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.MailingAddress)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.MailingCity)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.MailingZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.AdmIsActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.AdmUserAddedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.AdmUserModifiedFullName)
                .IsUnicode(false);

            modelBuilder.Entity<View_RequestFolioGrid>()
                .Property(e => e.RequestFolioTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<View_PSRAdmUserAdded>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<View_PSRCurrentlyAssigned>()
                .Property(e => e.CurrentlyAssigned)
                .IsUnicode(false);

        }
    }
}
