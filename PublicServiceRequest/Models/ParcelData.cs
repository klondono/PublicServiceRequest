namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DHMFRefresh")]
    public partial class ParcelData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long HKParcelData { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HistoryRunID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string Strap { get; set; }

        [StringLength(1000)]
        public string TrueSiteAddress { get; set; }

        [StringLength(1000)]
        public string TrueSiteAddressNoUnit { get; set; }

        [StringLength(50)]
        public string TrueSiteUnit { get; set; }

        [StringLength(50)]
        public string TrueSiteCity { get; set; }

        [StringLength(10)]
        public string TrueSiteZipCode { get; set; }

        [StringLength(50)]
        public string TrueMailingAddress1 { get; set; }

        [StringLength(50)]
        public string TrueMailingAddress2 { get; set; }

        [StringLength(50)]
        public string TrueMailingAddress3 { get; set; }

        [StringLength(50)]
        public string TrueMailingCity { get; set; }

        [StringLength(10)]
        public string TrueMailingState { get; set; }

        [StringLength(10)]
        public string TrueMailingZipCode { get; set; }

        [StringLength(50)]
        public string TrueMailingCountry { get; set; }

        [StringLength(100)]
        public string TrueOwner1 { get; set; }

        [StringLength(100)]
        public string TrueOwner2 { get; set; }

        [StringLength(100)]
        public string TrueOwner3 { get; set; }

        [StringLength(50)]
        public string MailingBlockLine1 { get; set; }

        [StringLength(50)]
        public string MailingBlockLine2 { get; set; }

        [StringLength(50)]
        public string MailingBlockLine3 { get; set; }

        [StringLength(50)]
        public string MailingBlockLine4 { get; set; }

        [StringLength(1)]
        public string CancelFlag { get; set; }

        [StringLength(1)]
        public string ReferenceOnlyFlag { get; set; }

        [StringLength(1)]
        public string ConfidentialFlag { get; set; }

        [StringLength(1)]
        public string ShowCurrentValuesFlag { get; set; }

        [StringLength(1)]
        public string CondoFlag { get; set; }

        [StringLength(13)]
        public string ParentStrap { get; set; }

        [StringLength(1)]
        public string TraverseHasBASSubarea { get; set; }

        [StringLength(1)]
        public string TraverseDrawableFlag { get; set; }

        [StringLength(1)]
        public string InteriorBuildFlag { get; set; }

        [StringLength(1)]
        public string LockFlag { get; set; }

        [StringLength(1)]
        public string LegalFlag { get; set; }

        [StringLength(1)]
        public string WidowExFlag { get; set; }

        [StringLength(1)]
        public string StatusCode { get; set; }

        [StringLength(2)]
        public string EconomicFlag { get; set; }

        [StringLength(1)]
        public string NFCFlag { get; set; }

        [StringLength(1)]
        public string ConsEasmntFlag { get; set; }

        [StringLength(1)]
        public string ConsCovenantFlag { get; set; }

        [StringLength(1)]
        public string CourtCaseFlag { get; set; }

        [StringLength(1)]
        public string SOHSaleFlag { get; set; }

        [StringLength(1)]
        public string LandSaleFlag { get; set; }

        [StringLength(1)]
        public string HXFlag { get; set; }

        [StringLength(1)]
        public string NHXFlag { get; set; }

        [StringLength(1)]
        public string OtherFlag { get; set; }

        [StringLength(1)]
        public string AgriculturalFlagCurrent { get; set; }

        [StringLength(1)]
        public string AgriculturalFlagPrior { get; set; }

        [StringLength(1)]
        public string AgriculturalFlagTwoPrior { get; set; }

        [StringLength(1)]
        public string EELUseFlagCurrent { get; set; }

        [StringLength(1)]
        public string EELUseFlagPrior { get; set; }

        [StringLength(1)]
        public string EELUseFlagTwoPrior { get; set; }

        [StringLength(1)]
        public string WaterfrontUseFlagCurrent { get; set; }

        [StringLength(1)]
        public string WaterfrontUseFlagPrior { get; set; }

        [StringLength(1)]
        public string WaterfrontUseFlagTwoPrior { get; set; }

        [StringLength(1)]
        public string AgriculturalUseFlagCurrent { get; set; }

        [StringLength(1)]
        public string AgriculturalUseFlagPrior { get; set; }

        [StringLength(1)]
        public string AgriculturalUseFlagTwoPrior { get; set; }

        [StringLength(1)]
        public string PoolFlag { get; set; }

        [StringLength(5)]
        public string MunicipalityCode { get; set; }

        [StringLength(50)]
        public string MunicipalityDescription { get; set; }

        [StringLength(1)]
        public string PrimaryValuationMethod { get; set; }

        [StringLength(50)]
        public string PrimaryValuationMethodDescription { get; set; }

        [StringLength(4)]
        public string Millage { get; set; }

        [StringLength(100)]
        public string MillageDescription { get; set; }

        [StringLength(4)]
        public string DORCodeCurrent { get; set; }

        [StringLength(100)]
        public string DORDescription { get; set; }

        [StringLength(4)]
        public string DORCodePrior { get; set; }

        [StringLength(4)]
        public string DORCodeTwoPrior { get; set; }

        [StringLength(2)]
        public string ClucCodeCurrent { get; set; }

        [StringLength(2)]
        public string ClucCodePrior { get; set; }

        [StringLength(2)]
        public string ClucCodeTwoPrior { get; set; }

        [StringLength(2)]
        public string SlucCodeCurrent { get; set; }

        [StringLength(2)]
        public string SlucCodePrior { get; set; }

        [StringLength(2)]
        public string SlucCodeTwoPrior { get; set; }

        [StringLength(4)]
        public string PrimaryZone { get; set; }

        [StringLength(50)]
        public string PrimaryZoneDescription { get; set; }

        [StringLength(4)]
        public string SecondaryZone { get; set; }

        [StringLength(50)]
        public string SecondaryZoneDescription { get; set; }

        [StringLength(2)]
        public string GroupCode { get; set; }

        [StringLength(4)]
        public string TincCode { get; set; }

        [StringLength(3)]
        public string PlateNumber { get; set; }

        [StringLength(15)]
        public string StripNumber { get; set; }

        [StringLength(2)]
        public string DeletedSplitCombinedCode { get; set; }

        [StringLength(20)]
        public string Agenda { get; set; }

        [StringLength(12)]
        public string Ordinance { get; set; }

        [StringLength(12)]
        public string PlatBook { get; set; }

        [StringLength(12)]
        public string PlatPage { get; set; }

        [StringLength(6)]
        public string ElectoralDistrict { get; set; }

        public int? District { get; set; }

        public decimal? Neighborhood { get; set; }

        [StringLength(50)]
        public string NeighborhoodDescription { get; set; }

        [StringLength(16)]
        public string Subdivision { get; set; }

        [StringLength(100)]
        public string SubdivisionDescription { get; set; }

        public int? BedroomCount { get; set; }

        public decimal? BathroomCount { get; set; }

        public int? HalfBathroomCount { get; set; }

        public int? FloorCount { get; set; }

        public int? UnitCount { get; set; }

        public int? EFCCount { get; set; }

        public int? BR1Count { get; set; }

        public int? BR2Count { get; set; }

        public int? BR3Count { get; set; }

        public int? BR4Count { get; set; }

        public int? BuildingCount { get; set; }

        public int? OwnerCount { get; set; }

        public decimal? CondoXFArea { get; set; }

        public decimal? CondoPRCXFArea { get; set; }

        public decimal? BuildingActualArea { get; set; }

        public decimal? BuildingBaseArea { get; set; }

        public decimal? BuildingEffectiveArea { get; set; }

        public decimal? BuildingGrossArea { get; set; }

        public decimal? BuildingHeatedArea { get; set; }

        public decimal? BuildingPRCArea { get; set; }

        public decimal? LotSize { get; set; }

        public short? ActualYearBuilt { get; set; }

        public short? EffectiveYearBuilt { get; set; }

        public short? YearBuilt { get; set; }

        public int? BaseYear { get; set; }

        public int? BaseYearNonHomestead { get; set; }

        public short? PercentHomesteadCapped { get; set; }

        public short? MaxExYear { get; set; }

        public int? PortYear { get; set; }

        public int? GrannyFlatExYear { get; set; }

        public int? YearAnnexed { get; set; }

        public DateTime? LastEditDate { get; set; }

        public DateTime? SplitDate { get; set; }

        public short? AssessmentYearCurrent { get; set; }

        public short? AssessmentYearPrior { get; set; }

        public short? AssessmentYearTwoPrior { get; set; }

        public decimal? LandValueCurrent { get; set; }

        public decimal? LandValuePrior { get; set; }

        public decimal? LandValueTwoPrior { get; set; }

        public decimal? BuildingValueCurrent { get; set; }

        public decimal? BuildingValuePrior { get; set; }

        public decimal? BuildingValueTwoPrior { get; set; }

        public decimal? BuildingOnlyValueCurrent { get; set; }

        public decimal? BuildingOnlyValuePrior { get; set; }

        public decimal? BuildingOnlyValueTwoPrior { get; set; }

        public decimal? ExtraFeatureValueCurrent { get; set; }

        public decimal? ExtraFeatureValuePrior { get; set; }

        public decimal? ExtraFeatureValueTwoPrior { get; set; }

        public decimal? TotalValueCurrent { get; set; }

        public decimal? TotalValuePrior { get; set; }

        public decimal? TotalValueTwoPrior { get; set; }

        public decimal? MarketValueCurrent { get; set; }

        public decimal? MarketValuePrior { get; set; }

        public decimal? MarketValueTwoPrior { get; set; }

        public decimal? AssessedValueCurrent { get; set; }

        public decimal? AssessedValuePrior { get; set; }

        public decimal? AssessedValueTwoPrior { get; set; }

        public decimal? NConValueCurrent { get; set; }

        public decimal? NConValuePrior { get; set; }

        public decimal? NConValueTwoPrior { get; set; }

        public decimal? DemoValueCurrent { get; set; }

        public decimal? DemoValuePrior { get; set; }

        public decimal? DemoValueTwoPrior { get; set; }

        public decimal? AgDifferentialValueCurrent { get; set; }

        public decimal? AgDifferentialValuePrior { get; set; }

        public decimal? AgDifferentialValueTwoPrior { get; set; }

        public decimal? NonCappedMarketValueCurrent { get; set; }

        public decimal? NonCappedMarketValuePrior { get; set; }

        public decimal? NonCappedMarketValueTwoPrior { get; set; }

        public decimal? CappedValueCurrent { get; set; }

        public decimal? CappedValuePrior { get; set; }

        public decimal? CappedValueTwoPrior { get; set; }

        public decimal? NonHomesiteLandValueCurrent { get; set; }

        public decimal? NonHomesiteLandValuePrior { get; set; }

        public decimal? NonHomesiteLandValueTwoPrior { get; set; }

        public decimal? PortValueCurrent { get; set; }

        public decimal? PortValuePrior { get; set; }

        public decimal? PortValueTwoPrior { get; set; }

        public decimal? CountyTaxableValueCurrent { get; set; }

        public decimal? CountyTaxableValuePrior { get; set; }

        public decimal? CountyTaxableValueTwoPrior { get; set; }

        public decimal? CountyExemptionValueCurrent { get; set; }

        public decimal? CountyExemptionValuePrior { get; set; }

        public decimal? CountyExemptionValueTwoPrior { get; set; }

        public decimal? CityTaxableValueCurrent { get; set; }

        public decimal? CityTaxableValuePrior { get; set; }

        public decimal? CityTaxableValueTwoPrior { get; set; }

        public decimal? CityExemptionValueCurrent { get; set; }

        public decimal? CityExemptionValuePrior { get; set; }

        public decimal? CityExemptionValueTwoPrior { get; set; }

        public decimal? RegionalTaxableValueCurrent { get; set; }

        public decimal? RegionalTaxableValuePrior { get; set; }

        public decimal? RegionalTaxableValueTwoPrior { get; set; }

        public decimal? RegionalExemptionValueCurrent { get; set; }

        public decimal? RegionalExemptionValuePrior { get; set; }

        public decimal? RegionalExemptionValueTwoPrior { get; set; }

        public decimal? SchoolTaxableValueCurrent { get; set; }

        public decimal? SchoolTaxableValuePrior { get; set; }

        public decimal? SchoolTaxableValueTwoPrior { get; set; }

        public decimal? SchoolAssessedValueCurrent { get; set; }

        public decimal? SchoolAssessedValuePrior { get; set; }

        public decimal? SchoolAssessedValueTwoPrior { get; set; }

        public decimal? SchoolExemptionValueCurrent { get; set; }

        public decimal? SchoolExemptionValuePrior { get; set; }

        public decimal? SchoolExemptionValueTwoPrior { get; set; }

        [StringLength(2)]
        public string StateExCodeCurrent { get; set; }

        [StringLength(2)]
        public string StateExCodeIICurrent { get; set; }

        [StringLength(2)]
        public string StateExCodePrior { get; set; }

        [StringLength(2)]
        public string StateExCodeIIPrior { get; set; }

        public decimal? StateExValueCurrent { get; set; }

        public decimal? StateExValuePrior { get; set; }

        public decimal? StateExValueTwoPrior { get; set; }

        public decimal? TotalExValueCurrent { get; set; }

        public decimal? TotalExValuePrior { get; set; }

        public decimal? TotalExValueTwoPrior { get; set; }

        public decimal? HomesteadExValueCurrent { get; set; }

        public decimal? HomesteadExValuePrior { get; set; }

        public decimal? HomesteadExValueTwoPrior { get; set; }

        public decimal? WidowExValueCurrent { get; set; }

        public decimal? WidowExValuePrior { get; set; }

        public decimal? WidowExValueTwoPrior { get; set; }

        public decimal? VeteranExValueCurrent { get; set; }

        public decimal? VeteranExValuePrior { get; set; }

        public decimal? VeteranExValueTwoPrior { get; set; }

        public decimal? DisabledExValueCurrent { get; set; }

        public decimal? DisabledExValuePrior { get; set; }

        public decimal? DisabledExValueTwoPrior { get; set; }

        public decimal? BlindExValueCurrent { get; set; }

        public decimal? BlindExValuePrior { get; set; }

        public decimal? BlindExValueTwoPrior { get; set; }

        public decimal? GrannyFlatExValueCurrent { get; set; }

        public decimal? GrannyFlatExValuePrior { get; set; }

        public decimal? GrannyFlatExValueTwoPrior { get; set; }

        public decimal? CountySecondHomesteadExValueCurrent { get; set; }

        public decimal? CountySecondHomesteadExValuePrior { get; set; }

        public decimal? CountySecondHomesteadExValueTwoPrior { get; set; }

        public decimal? CitySecondHomesteadExValueCurrent { get; set; }

        public decimal? CitySecondHomesteadExValuePrior { get; set; }

        public decimal? CitySecondHomesteadExValueTwoPrior { get; set; }

        public decimal? RegionalSecondHomesteadExValueCurrent { get; set; }

        public decimal? RegionalSecondHomesteadExValuePrior { get; set; }

        public decimal? RegionalSecondHomesteadExValueTwoPrior { get; set; }

        public decimal? CountySeniorExValueCurrent { get; set; }

        public decimal? CountySeniorExValuePrior { get; set; }

        public decimal? CountySeniorExValueTwoPrior { get; set; }

        public decimal? CitySeniorExValueCurrent { get; set; }

        public decimal? CitySeniorExValuePrior { get; set; }

        public decimal? CitySeniorExValueTwoPrior { get; set; }

        public decimal? CountyLongTermSeniorExValueCurrent { get; set; }

        public decimal? CountyLongTermSeniorExValuePrior { get; set; }

        public decimal? CountyLongTermSeniorExValueTwoPrior { get; set; }

        public decimal? CityLongTermSeniorExValueCurrent { get; set; }

        public decimal? CityLongTermSeniorExValuePrior { get; set; }

        public decimal? CityLongTermSeniorExValueTwoPrior { get; set; }

        public decimal? CountyOtherExValueCurrent { get; set; }

        public decimal? CountyOtherExValuePrior { get; set; }

        public decimal? CountyOtherExValueTwoPrior { get; set; }

        public decimal? CityOtherExValueCurrent { get; set; }

        public decimal? CityOtherExValuePrior { get; set; }

        public decimal? CityOtherExValueTwoPrior { get; set; }

        public short? VeteranAbtExPercentCurrent { get; set; }

        public short? VeteranAbtExPercentPrior { get; set; }

        public short? VeteranAbtExPercentTwoPrior { get; set; }

        public long? FHKLu_mill_cd { get; set; }

        public long? FHKLu_city { get; set; }
    }
}
