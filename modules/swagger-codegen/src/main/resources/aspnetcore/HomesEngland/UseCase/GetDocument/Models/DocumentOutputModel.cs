using System;
using HomesEngland.Domain;

namespace HomesEngland.UseCase.GetDocument.Models
{
    public class DocumentOutputModel
    {
        public int Id { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public DocumentOutputModel(){}

        public DocumentOutputModel(IDocument document)
        {
            Id = document.Id;
            ModifiedDateTime = document.ModifiedDateTime;

            Programme = document.Programme;
            EquityOwner = document.EquityOwner;
            SchemeId = document.SchemeId;
            LocationLaRegionName = document.LocationLaRegionName;
            ImsOldRegion = document.ImsOldRegion;
            NoOfBeds = document.NoOfBeds;
            Address = document.Address;
            PropertyHouseName = document.PropertyHouseName;
            PropertyStreetNumber = document.PropertyStreetNumber;
            PropertyStreet = document.PropertyStreet;
            PropertyTown = document.PropertyTown;
            PropertyPostcode = document.PropertyPostcode;
            DevelopingRslName = document.DevelopingRslName;
            LBHA = document.LBHA;
            CompletionDateForHpiStart = document.CompletionDateForHpiStart;
            ImsActualCompletionDate = document.ImsActualCompletionDate;
            ImsExpectedCompletionDate = document.ImsExpectedCompletionDate;
            ImsLegalCompletionDate = document.ImsLegalCompletionDate;
            HopCompletionDate = document.HopCompletionDate;
            Deposit = document.Deposit;
            AgencyEquityLoan = document.AgencyEquityLoan;
            DeveloperEquityLoan = document.DeveloperEquityLoan;
            ShareOfRestrictedEquity = document.ShareOfRestrictedEquity;
            DeveloperDiscount = document.DeveloperDiscount;
            Mortgage = document.Mortgage;
            PurchasePrice = document.PurchasePrice;
            Fees = document.Fees;
            HistoricUnallocatedFees = document.HistoricUnallocatedFees;
            ActualAgencyEquityCostIncludingHomeBuyAgentFee = document.ActualAgencyEquityCostIncludingHomeBuyAgentFee;
            FullDisposalDate = document.FullDisposalDate;
            OriginalAgencyPercentage = document.OriginalAgencyPercentage;
            StaircasingPercentage = document.StaircasingPercentage;
            NewAgencyPercentage = document.NewAgencyPercentage;
            Invested = document.Invested;
            Month = document.Month;
            CalendarYear = document.CalendarYear;
            MMYYYY = document.MMYYYY;
            Row = document.Row;
            Col = document.Col;
            HPIStart = document.HPIStart;
            HPIEnd = document.HPIEnd;
            HPIPlusMinus = document.HPIPlusMinus;
            AgencyPercentage = document.AgencyPercentage;
            MortgageEffect = document.MortgageEffect;
            RemainingAgencyCost = document.RemainingAgencyCost;
            WAEstimatedPropertyValue = document.WAEstimatedPropertyValue;
            AgencyFairValueDifference = document.AgencyFairValueDifference;
            ImpairmentProvision = document.ImpairmentProvision;
            FairValueReserve = document.FairValueReserve;
            AgencyFairValue = document.AgencyFairValue;
            DisposalsCost = document.DisposalsCost;
            DurationInMonths = document.DurationInMonths;
            MonthOfCompletionSinceSchemeStart = document.MonthOfCompletionSinceSchemeStart;
            DisposalMonthSinceCompletion = document.DisposalMonthSinceCompletion;
            IMSPaymentDate = document.IMSPaymentDate;
            IsPaid = document.IsPaid;
            IsAsset = document.IsAsset;
            PropertyType = document.PropertyType;
            Tenure = document.Tenure;
            ExpectedStaircasingRate = document.ExpectedStaircasingRate;
            EstimatedSalePrice = document.EstimatedSalePrice;
            RegionalSaleAdjust = document.RegionalSaleAdjust;
            RegionalStairAdjust = document.RegionalStairAdjust;
            NotLimitedByFirstCharge = document.NotLimitedByFirstCharge;
            EarlyMortgageIfNeverRepay = document.EarlyMortgageIfNeverRepay;
            ArrearsEffectAppliedOrLimited = document.ArrearsEffectAppliedOrLimited;
            RelativeSalePropertyTypeAndTenureAdjustment = document.RelativeSalePropertyTypeAndTenureAdjustment;
            RelativeStairPropertyTypeAndTenureAdjustment = document.RelativeStairPropertyTypeAndTenureAdjustment;
            IsLondon = document.IsLondon;
            QuarterSpend = document.QuarterSpend;
            MortgageProvider = document.MortgageProvider;
            HouseType = document.HouseType;
            PurchasePriceBand = document.PurchasePriceBand;
            HouseholdFiveKIncomeBand = document.HouseholdFiveKIncomeBand;
            HouseholdFiftyKIncomeBand = document.HouseholdFiftyKIncomeBand;
            FirstTimeBuyer = document.FirstTimeBuyer;

            HouseholdIncome = document.HouseholdIncome;
            EstimatedValuation = document.EstimatedValuation;

            AssetRegisterVersionId = document.AssetRegisterVersionId;
        }

        public string Programme { get; set; }
        public string EquityOwner { get; set; }
        public int? SchemeId { get; set; }
        public string LocationLaRegionName { get; set; }
        public string ImsOldRegion { get; set; }
        public int? NoOfBeds { get; set; }
        public string Address { get; set; }
        public string PropertyHouseName { get; set; }
        public string PropertyStreetNumber { get; set; }
        public string PropertyStreet { get; set; }
        public string PropertyTown { get; set; }
        public string PropertyPostcode { get; set; }
        public string DevelopingRslName { get; set; }
        public string LBHA { get; set; }
        public DateTime? CompletionDateForHpiStart { get; set; }
        public DateTime? ImsActualCompletionDate { get; set; }
        public DateTime? ImsExpectedCompletionDate { get; set; }
        public DateTime? ImsLegalCompletionDate { get; set; }
        public DateTime? HopCompletionDate { get; set; }
        public decimal? Deposit { get; set; }
        public decimal? AgencyEquityLoan { get; set; }
        public decimal? DeveloperEquityLoan { get; set; }
        public decimal? ShareOfRestrictedEquity { get; set; }
        public decimal? DeveloperDiscount { get; set; }
        public decimal? Mortgage { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? Fees { get; set; }
        public decimal? HistoricUnallocatedFees { get; set; }
        public decimal? ActualAgencyEquityCostIncludingHomeBuyAgentFee { get; set; }
        public DateTime? FullDisposalDate { get; set; }
        public decimal? OriginalAgencyPercentage { get; set; }
        public decimal? StaircasingPercentage { get; set; }
        public decimal? NewAgencyPercentage { get; set; }
        public int? Invested { get; set; }
        public int? Month { get; set; }
        public int? CalendarYear { get; set; }
        public string MMYYYY { get; set; }
        public int? Row { get; set; }
        public int? Col { get; set; }
        public decimal? HPIStart { get; set; }
        public decimal? HPIEnd { get; set; }
        public decimal? HPIPlusMinus { get; set; }
        public decimal? AgencyPercentage { get; set; }
        public decimal? MortgageEffect { get; set; }
        public decimal? RemainingAgencyCost { get; set; }
        public decimal? WAEstimatedPropertyValue { get; set; }
        public decimal? AgencyFairValueDifference { get; set; }
        public decimal? ImpairmentProvision { get; set; }
        public decimal? FairValueReserve { get; set; }
        public decimal? AgencyFairValue { get; set; }
        public decimal? DisposalsCost { get; set; }
        public decimal? DurationInMonths { get; set; }
        public decimal? MonthOfCompletionSinceSchemeStart { get; set; }
        public decimal? DisposalMonthSinceCompletion { get; set; }
        public DateTime? IMSPaymentDate { get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsAsset { get; set; }
        public string PropertyType { get; set; }
        public string Tenure { get; set; }
        public decimal? ExpectedStaircasingRate { get; set; }
        public decimal? EstimatedSalePrice { get; set; }
        public decimal? EstimatedValuation { get; set; }
        public decimal? RegionalSaleAdjust { get; set; }
        public decimal? RegionalStairAdjust { get; set; }
        public bool? NotLimitedByFirstCharge { get; set; }
        public decimal? EarlyMortgageIfNeverRepay { get; set; }
        public string ArrearsEffectAppliedOrLimited { get; set; }
        public decimal? RelativeSalePropertyTypeAndTenureAdjustment { get; set; }
        public decimal? RelativeStairPropertyTypeAndTenureAdjustment { get; set; }
        public bool? IsLondon { get; set; }
        public decimal? QuarterSpend { get; set; }
        public string MortgageProvider { get; set; }
        public string HouseType { get; set; }
        public decimal? PurchasePriceBand { get; set; }
        public decimal? HouseholdIncome { get; set; }
        public decimal? HouseholdFiveKIncomeBand { get; set; }
        public decimal? HouseholdFiftyKIncomeBand { get; set; }
        public bool? FirstTimeBuyer { get; set; }
        public int? AssetRegisterVersionId { get; set; }
    }
}
