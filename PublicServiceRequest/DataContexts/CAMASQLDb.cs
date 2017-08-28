namespace CustomerService_PSR.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Utilities;

    public partial class CAMASQLDb : BaseDbContext
    {
        public CAMASQLDb()
            : base("name=CAMASQLDb")
        {
        }

        public virtual DbSet<ParcelData> ParcelData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParcelData>()
                .Property(e => e.Strap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueSiteAddress)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueSiteAddressNoUnit)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueSiteUnit)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueSiteCity)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueSiteZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueMailingAddress1)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueMailingAddress2)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueMailingAddress3)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueMailingCity)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueMailingState)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueMailingZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueMailingCountry)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueOwner1)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueOwner2)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TrueOwner3)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.MailingBlockLine1)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.MailingBlockLine2)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.MailingBlockLine3)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.MailingBlockLine4)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CancelFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.ReferenceOnlyFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.ConfidentialFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.ShowCurrentValuesFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CondoFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.ParentStrap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TraverseHasBASSubarea)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TraverseDrawableFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.InteriorBuildFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.LockFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.LegalFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.WidowExFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.StatusCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.EconomicFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.NFCFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.ConsEasmntFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.ConsCovenantFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CourtCaseFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SOHSaleFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.LandSaleFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.HXFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.NHXFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.OtherFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.AgriculturalFlagCurrent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.AgriculturalFlagPrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.AgriculturalFlagTwoPrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.EELUseFlagCurrent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.EELUseFlagPrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.EELUseFlagTwoPrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.WaterfrontUseFlagCurrent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.WaterfrontUseFlagPrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.WaterfrontUseFlagTwoPrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.AgriculturalUseFlagCurrent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.AgriculturalUseFlagPrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.AgriculturalUseFlagTwoPrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.PoolFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.MunicipalityCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.MunicipalityDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.PrimaryValuationMethod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.PrimaryValuationMethodDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.Millage)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.MillageDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.DORCodeCurrent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.DORDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.DORCodePrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.DORCodeTwoPrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.ClucCodeCurrent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.ClucCodePrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.ClucCodeTwoPrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SlucCodeCurrent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SlucCodePrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SlucCodeTwoPrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.PrimaryZone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.PrimaryZoneDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SecondaryZone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SecondaryZoneDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.GroupCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TincCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.PlateNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.StripNumber)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.DeletedSplitCombinedCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.Agenda)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.Ordinance)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.PlatBook)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.PlatPage)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.ElectoralDistrict)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.NeighborhoodDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.Subdivision)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SubdivisionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.BathroomCount)
                .HasPrecision(8, 2);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.LandValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.LandValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.LandValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.BuildingValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.BuildingValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.BuildingValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.BuildingOnlyValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.BuildingOnlyValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.BuildingOnlyValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.ExtraFeatureValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.ExtraFeatureValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.ExtraFeatureValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TotalValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TotalValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TotalValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.MarketValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.MarketValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.MarketValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.AssessedValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.AssessedValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.AssessedValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.NConValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.NConValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.NConValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.DemoValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.DemoValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.DemoValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.AgDifferentialValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.AgDifferentialValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.AgDifferentialValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.NonCappedMarketValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.NonCappedMarketValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.NonCappedMarketValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CappedValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CappedValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CappedValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.NonHomesiteLandValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.NonHomesiteLandValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.NonHomesiteLandValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.PortValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.PortValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.PortValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountyTaxableValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountyTaxableValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountyTaxableValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountyExemptionValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountyExemptionValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountyExemptionValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CityTaxableValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CityTaxableValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CityTaxableValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CityExemptionValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CityExemptionValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CityExemptionValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.RegionalTaxableValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.RegionalTaxableValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.RegionalTaxableValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.RegionalExemptionValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.RegionalExemptionValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.RegionalExemptionValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SchoolTaxableValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SchoolTaxableValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SchoolTaxableValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SchoolAssessedValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SchoolAssessedValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SchoolAssessedValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SchoolExemptionValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SchoolExemptionValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.SchoolExemptionValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.StateExCodeCurrent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.StateExCodeIICurrent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.StateExCodePrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.StateExCodeIIPrior)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.StateExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.StateExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.StateExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TotalExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TotalExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.TotalExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.HomesteadExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.HomesteadExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.HomesteadExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.WidowExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.WidowExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.WidowExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.VeteranExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.VeteranExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.VeteranExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.DisabledExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.DisabledExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.DisabledExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.BlindExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.BlindExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.BlindExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.GrannyFlatExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.GrannyFlatExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.GrannyFlatExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountySecondHomesteadExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountySecondHomesteadExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountySecondHomesteadExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CitySecondHomesteadExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CitySecondHomesteadExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CitySecondHomesteadExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.RegionalSecondHomesteadExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.RegionalSecondHomesteadExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.RegionalSecondHomesteadExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountySeniorExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountySeniorExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountySeniorExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CitySeniorExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CitySeniorExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CitySeniorExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountyLongTermSeniorExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountyLongTermSeniorExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountyLongTermSeniorExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CityLongTermSeniorExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CityLongTermSeniorExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CityLongTermSeniorExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountyOtherExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountyOtherExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CountyOtherExValueTwoPrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CityOtherExValueCurrent)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CityOtherExValuePrior)
                .HasPrecision(12, 0);

            modelBuilder.Entity<ParcelData>()
                .Property(e => e.CityOtherExValueTwoPrior)
                .HasPrecision(12, 0);

        }

        public int GetCurrentHistoryRunID()
        {
            return Database.SqlQuery<int>("SELECT dbo.GetDefaultHistoryRunID()").ToList()[0];
        }

        public int GetCurrentRollYear()
        {
            return Database.SqlQuery<int>("SELECT [dbo].[GetCurrentRollYear] ()").FirstOrDefault();
        }

        public ParcelData GetParcelData(string strFolio, int intHistoryRunID = 999999)
        {
            if (intHistoryRunID == 999999) intHistoryRunID = GetCurrentHistoryRunID();

            return ParcelData.Find(intHistoryRunID, strFolio);
        }
    }
}
