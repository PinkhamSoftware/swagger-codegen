using System;
using FluentAssertions;
using HomesEngland.Domain;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.GetDocument.Models;

namespace TestHelper
{

    public static class AssetTestHelper
    {
        /// <summary>
        /// Some database store Datetime Seconds fields to 6 decimal places instead of 7
        /// this helps compare the 2 entities in that case
        /// </summary>
        /// <param name="readDocument"></param>
        /// <param name="entity"></param>
        public static void AssetIsEqual(this IDocument readDocument, IDocument entity)
        {
            readDocument.Id.Should().Be(entity.Id);
            readDocument.ModifiedDateTime.Should().BeCloseTo(entity.ModifiedDateTime, TimeSpan.FromMilliseconds(1.0));

            readDocument.Programme.Should().BeEquivalentTo(entity.Programme);
            readDocument.EquityOwner.Should().BeEquivalentTo(entity.EquityOwner);
            readDocument.SchemeId.Should().Be(entity.SchemeId);
            readDocument.LocationLaRegionName.Should().BeEquivalentTo(entity.LocationLaRegionName);
            readDocument.ImsOldRegion.Should().BeEquivalentTo(entity.ImsOldRegion);
            readDocument.NoOfBeds.Should().Be(entity.NoOfBeds);
            readDocument.Address.Should().BeEquivalentTo(entity.Address);
            readDocument.PropertyHouseName.Should().BeEquivalentTo(entity.PropertyHouseName);
            readDocument.PropertyStreetNumber.Should().BeEquivalentTo(entity.PropertyStreetNumber);
            readDocument.PropertyStreet.Should().BeEquivalentTo(entity.PropertyStreet);
            readDocument.PropertyTown.Should().BeEquivalentTo(entity.PropertyTown);
            readDocument.PropertyPostcode.Should().BeEquivalentTo(entity.PropertyPostcode);
            readDocument.DevelopingRslName.Should().BeEquivalentTo(entity.DevelopingRslName);
            readDocument.LBHA.Should().BeEquivalentTo(entity.LBHA);
            readDocument.CompletionDateForHpiStart.Should().BeCloseTo(entity.CompletionDateForHpiStart.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.ImsActualCompletionDate.Should().BeCloseTo(entity.ImsActualCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.ImsExpectedCompletionDate.Should().BeCloseTo(entity.ImsExpectedCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.ImsLegalCompletionDate.Should().BeCloseTo(entity.ImsLegalCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.HopCompletionDate.Should().BeCloseTo(entity.HopCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.Deposit.Should().Be(entity.Deposit);
            readDocument.AgencyEquityLoan.Should().Be(entity.AgencyEquityLoan);
            readDocument.DeveloperEquityLoan.Should().Be(entity.DeveloperEquityLoan);
            readDocument.ShareOfRestrictedEquity.Should().Be(entity.ShareOfRestrictedEquity);
            readDocument.DeveloperDiscount.Should().Be(entity.DeveloperDiscount);
            readDocument.Mortgage.Should().Be(entity.Mortgage);
            readDocument.PurchasePrice.Should().Be(entity.PurchasePrice);
            readDocument.Fees.Should().Be(entity.Fees);
            readDocument.HistoricUnallocatedFees.Should().Be(entity.HistoricUnallocatedFees);
            readDocument.ActualAgencyEquityCostIncludingHomeBuyAgentFee.Should().Be(entity.ActualAgencyEquityCostIncludingHomeBuyAgentFee);
            readDocument.FullDisposalDate.Should().BeCloseTo(entity.FullDisposalDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.OriginalAgencyPercentage.Should().Be(entity.OriginalAgencyPercentage);
            readDocument.StaircasingPercentage.Should().Be(entity.StaircasingPercentage);
            readDocument.NewAgencyPercentage.Should().Be(entity.NewAgencyPercentage);
            readDocument.Invested.Should().Be(entity.Invested);
            readDocument.Month.Should().Be(entity.Month);
            readDocument.CalendarYear.Should().Be(entity.CalendarYear);
            readDocument.MMYYYY.Should().BeEquivalentTo(entity.MMYYYY);
            readDocument.Row.Should().Be(entity.Row);
            readDocument.Col.Should().Be(entity.Col);
            readDocument.HPIStart.Should().Be(entity.HPIStart);
            readDocument.HPIEnd.Should().Be(entity.HPIEnd);
            readDocument.HPIPlusMinus.Should().Be(entity.HPIPlusMinus);
            readDocument.AgencyPercentage.Should().Be(entity.AgencyPercentage);
            readDocument.MortgageEffect.Should().Be(entity.MortgageEffect);
            readDocument.RemainingAgencyCost.Should().Be(entity.RemainingAgencyCost);
            readDocument.WAEstimatedPropertyValue.Should().Be(entity.WAEstimatedPropertyValue);
            readDocument.AgencyFairValueDifference.Should().Be(entity.AgencyFairValueDifference);
            readDocument.ImpairmentProvision.Should().Be(entity.ImpairmentProvision);
            readDocument.FairValueReserve.Should().Be(entity.FairValueReserve);
            readDocument.AgencyFairValue.Should().Be(entity.AgencyFairValue);
            readDocument.DisposalsCost.Should().Be(entity.DisposalsCost);
            readDocument.DurationInMonths.Should().Be(entity.DurationInMonths);
            readDocument.MonthOfCompletionSinceSchemeStart.Should().Be(entity.MonthOfCompletionSinceSchemeStart);
            readDocument.DisposalMonthSinceCompletion.Should().Be(entity.DisposalMonthSinceCompletion);
            readDocument.IMSPaymentDate.Should().BeCloseTo(entity.IMSPaymentDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.IsPaid.Should().Be(entity.IsPaid);
            readDocument.IsAsset.Should().Be(entity.IsAsset);
            readDocument.PropertyType.Should().BeEquivalentTo(entity.PropertyType);
            readDocument.Tenure.Should().BeEquivalentTo(entity.Tenure);
            readDocument.ExpectedStaircasingRate.Should().Be(entity.ExpectedStaircasingRate);
            readDocument.EstimatedSalePrice.Should().Be(entity.EstimatedSalePrice);
            readDocument.RegionalSaleAdjust.Should().Be(entity.RegionalSaleAdjust);
            readDocument.RegionalStairAdjust.Should().Be(entity.RegionalStairAdjust);
            readDocument.NotLimitedByFirstCharge.Should().Be(entity.NotLimitedByFirstCharge);
            readDocument.EarlyMortgageIfNeverRepay.Should().Be(entity.EarlyMortgageIfNeverRepay);
            readDocument.ArrearsEffectAppliedOrLimited.Should().Be(entity.ArrearsEffectAppliedOrLimited);
            readDocument.RelativeSalePropertyTypeAndTenureAdjustment.Should().Be(entity.RelativeSalePropertyTypeAndTenureAdjustment);
            readDocument.RelativeStairPropertyTypeAndTenureAdjustment.Should().Be(entity.RelativeStairPropertyTypeAndTenureAdjustment);
            readDocument.IsLondon.Should().Be(entity.IsLondon);
            readDocument.QuarterSpend.Should().Be(entity.QuarterSpend);
            readDocument.MortgageProvider.Should().Be(entity.MortgageProvider);
            readDocument.HouseType.Should().Be(entity.HouseType);
            readDocument.PurchasePriceBand.Should().Be(entity.PurchasePriceBand);
            readDocument.HouseholdFiveKIncomeBand.Should().Be(entity.HouseholdFiveKIncomeBand);
            readDocument.HouseholdFiftyKIncomeBand.Should().Be(entity.HouseholdFiftyKIncomeBand);
            readDocument.FirstTimeBuyer.Should().Be(entity.FirstTimeBuyer);

            readDocument.HouseholdIncome.Should().Be(entity.HouseholdIncome);
            readDocument.EstimatedValuation.Should().Be(entity.EstimatedValuation);
        }

        /// <summary>
        /// Some database store Datetime Seconds fields to 6 decimal places instead of 7
        /// this helps compare the 2 entities in that case
        /// </summary>
        /// <param name="readDocument"></param>
        /// <param name="entity"></param>
        public static bool AssetIsEqual(this IDocument readDocument, CreateDocumentRequest entity)
        {
            return
                readDocument.Programme.Equals(entity.Programme) &&
                readDocument.EquityOwner.Equals(entity.EquityOwner) &&
                readDocument.SchemeId.Equals(entity.SchemeId) &&
                readDocument.LocationLaRegionName.Equals(entity.LocationLaRegionName) &&
                readDocument.ImsOldRegion.Equals(entity.ImsOldRegion) &&
                readDocument.NoOfBeds.Equals(entity.NoOfBeds) &&
                readDocument.Address.Equals(entity.Address) &&
                readDocument.PropertyHouseName.Equals(entity.PropertyHouseName) &&
                readDocument.PropertyStreetNumber.Equals(entity.PropertyStreetNumber) &&
                readDocument.PropertyStreet.Equals(entity.PropertyStreet) &&
                readDocument.PropertyTown.Equals(entity.PropertyTown) &&
                readDocument.PropertyPostcode.Equals(entity.PropertyPostcode) &&
                readDocument.DevelopingRslName.Equals(entity.DevelopingRslName) &&
                readDocument.LBHA.Equals(entity.LBHA) &&
                readDocument.CompletionDateForHpiStart.Equals(entity.CompletionDateForHpiStart.Value) &&
                readDocument.ImsActualCompletionDate.Equals(entity.ImsActualCompletionDate.Value) &&
                readDocument.ImsExpectedCompletionDate.Equals(entity.ImsExpectedCompletionDate.Value) &&
                readDocument.ImsLegalCompletionDate.Equals(entity.ImsLegalCompletionDate.Value) &&
                readDocument.HopCompletionDate.Equals(entity.HopCompletionDate.Value) &&
                readDocument.Deposit.Equals(entity.Deposit) &&
                readDocument.AgencyEquityLoan.Equals(entity.AgencyEquityLoan) &&
                readDocument.DeveloperEquityLoan.Equals(entity.DeveloperEquityLoan) &&
                readDocument.ShareOfRestrictedEquity.Equals(entity.ShareOfRestrictedEquity) &&
                readDocument.DeveloperDiscount.Equals(entity.DeveloperDiscount) &&
                readDocument.Mortgage.Equals(entity.Mortgage) &&
                readDocument.PurchasePrice.Equals(entity.PurchasePrice) &&
                readDocument.Fees.Equals(entity.Fees) &&
                readDocument.HistoricUnallocatedFees.Equals(entity.HistoricUnallocatedFees) &&
                readDocument.ActualAgencyEquityCostIncludingHomeBuyAgentFee.Equals(entity
                    .ActualAgencyEquityCostIncludingHomeBuyAgentFee) &&
                readDocument.FullDisposalDate.Equals(entity.FullDisposalDate.Value) &&
                readDocument.OriginalAgencyPercentage.Equals(entity.OriginalAgencyPercentage) &&
                readDocument.StaircasingPercentage.Equals(entity.StaircasingPercentage) &&
                readDocument.NewAgencyPercentage.Equals(entity.NewAgencyPercentage) &&
                readDocument.Invested.Equals(entity.Invested) &&
                readDocument.Month.Equals(entity.Month) &&
                readDocument.CalendarYear.Equals(entity.CalendarYear) &&
                readDocument.MMYYYY.Equals(entity.MMYYYY) &&
                readDocument.Row.Equals(entity.Row) &&
                readDocument.Col.Equals(entity.Col) &&
                readDocument.HPIStart.Equals(entity.HPIStart) &&
                readDocument.HPIEnd.Equals(entity.HPIEnd) &&
                readDocument.HPIPlusMinus.Equals(entity.HPIPlusMinus) &&
                readDocument.AgencyPercentage.Equals(entity.AgencyPercentage) &&
                readDocument.MortgageEffect.Equals(entity.MortgageEffect) &&
                readDocument.RemainingAgencyCost.Equals(entity.RemainingAgencyCost) &&
                readDocument.WAEstimatedPropertyValue.Equals(entity.WAEstimatedPropertyValue) &&
                readDocument.AgencyFairValueDifference.Equals(entity.AgencyFairValueDifference) &&
                readDocument.ImpairmentProvision.Equals(entity.ImpairmentProvision) &&
                readDocument.FairValueReserve.Equals(entity.FairValueReserve) &&
                readDocument.AgencyFairValue.Equals(entity.AgencyFairValue) &&
                readDocument.DisposalsCost.Equals(entity.DisposalsCost) &&
                readDocument.DurationInMonths.Equals(entity.DurationInMonths) &&
                readDocument.MonthOfCompletionSinceSchemeStart.Equals(entity.MonthOfCompletionSinceSchemeStart) &&
                readDocument.DisposalMonthSinceCompletion.Equals(entity.DisposalMonthSinceCompletion) &&
                readDocument.IMSPaymentDate.Equals(entity.IMSPaymentDate.Value) &&
                readDocument.IsPaid.Equals(entity.IsPaid) &&
                readDocument.IsAsset.Equals(entity.IsAsset) &&
                readDocument.PropertyType.Equals(entity.PropertyType) &&
                readDocument.Tenure.Equals(entity.Tenure) &&
                readDocument.ExpectedStaircasingRate.Equals(entity.ExpectedStaircasingRate) &&
                readDocument.EstimatedSalePrice.Equals(entity.EstimatedSalePrice) &&
                readDocument.RegionalSaleAdjust.Equals(entity.RegionalSaleAdjust) &&
                readDocument.RegionalStairAdjust.Equals(entity.RegionalStairAdjust) &&
                readDocument.NotLimitedByFirstCharge.Equals(entity.NotLimitedByFirstCharge) &&
                readDocument.EarlyMortgageIfNeverRepay.Equals(entity.EarlyMortgageIfNeverRepay) &&
                readDocument.ArrearsEffectAppliedOrLimited.Equals(entity.ArrearsEffectAppliedOrLimited) &&
                readDocument.RelativeSalePropertyTypeAndTenureAdjustment.Equals(entity
                    .RelativeSalePropertyTypeAndTenureAdjustment) &&
                readDocument.RelativeStairPropertyTypeAndTenureAdjustment.Equals(entity
                    .RelativeStairPropertyTypeAndTenureAdjustment) &&
                readDocument.IsLondon.Equals(entity.IsLondon) &&
                readDocument.QuarterSpend.Equals(entity.QuarterSpend) &&
                readDocument.MortgageProvider.Equals(entity.MortgageProvider) &&
                readDocument.HouseType.Equals(entity.HouseType) &&
                readDocument.PurchasePriceBand.Equals(entity.PurchasePriceBand) &&
                readDocument.HouseholdFiveKIncomeBand.Equals(entity.HouseholdFiveKIncomeBand) &&
                readDocument.HouseholdFiftyKIncomeBand.Equals(entity.HouseholdFiftyKIncomeBand) &&
                readDocument.FirstTimeBuyer.Equals(entity.FirstTimeBuyer) &&

                readDocument.HouseholdIncome.Equals(entity.HouseholdIncome) &&
                readDocument.EstimatedValuation.Equals(entity.EstimatedValuation);
        }

        /// <summary>
        /// Some database store Datetime Seconds fields to 6 decimal places instead of 7
        /// this helps compare the 2 entities in that case
        /// </summary>
        /// <param name="readDocument"></param>
        /// <param name="entity"></param>
        public static void AssetOutputModelIsEqual(this DocumentOutputModel readDocument, CreateDocumentRequest entity)
        {
            readDocument.Programme.Should().BeEquivalentTo(entity.Programme);
            readDocument.EquityOwner.Should().BeEquivalentTo(entity.EquityOwner);
            readDocument.SchemeId.Should().Be(entity.SchemeId);
            readDocument.LocationLaRegionName.Should().BeEquivalentTo(entity.LocationLaRegionName);
            readDocument.ImsOldRegion.Should().BeEquivalentTo(entity.ImsOldRegion);
            readDocument.NoOfBeds.Should().Be(entity.NoOfBeds);
            readDocument.Address.Should().BeEquivalentTo(entity.Address);
            readDocument.PropertyHouseName.Should().BeEquivalentTo(entity.PropertyHouseName);
            readDocument.PropertyStreetNumber.Should().BeEquivalentTo(entity.PropertyStreetNumber);
            readDocument.PropertyStreet.Should().BeEquivalentTo(entity.PropertyStreet);
            readDocument.PropertyTown.Should().BeEquivalentTo(entity.PropertyTown);
            readDocument.PropertyPostcode.Should().BeEquivalentTo(entity.PropertyPostcode);
            readDocument.DevelopingRslName.Should().BeEquivalentTo(entity.DevelopingRslName);
            readDocument.LBHA.Should().BeEquivalentTo(entity.LBHA);
            readDocument.CompletionDateForHpiStart.Should().BeCloseTo(entity.CompletionDateForHpiStart.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.ImsActualCompletionDate.Should().BeCloseTo(entity.ImsActualCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.ImsExpectedCompletionDate.Should().BeCloseTo(entity.ImsExpectedCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.ImsLegalCompletionDate.Should().BeCloseTo(entity.ImsLegalCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.HopCompletionDate.Should().BeCloseTo(entity.HopCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.Deposit.Should().Be(entity.Deposit);
            readDocument.AgencyEquityLoan.Should().Be(entity.AgencyEquityLoan);
            readDocument.DeveloperEquityLoan.Should().Be(entity.DeveloperEquityLoan);
            readDocument.ShareOfRestrictedEquity.Should().Be(entity.ShareOfRestrictedEquity);
            readDocument.DeveloperDiscount.Should().Be(entity.DeveloperDiscount);
            readDocument.Mortgage.Should().Be(entity.Mortgage);
            readDocument.PurchasePrice.Should().Be(entity.PurchasePrice);
            readDocument.Fees.Should().Be(entity.Fees);
            readDocument.HistoricUnallocatedFees.Should().Be(entity.HistoricUnallocatedFees);
            readDocument.ActualAgencyEquityCostIncludingHomeBuyAgentFee.Should().Be(entity.ActualAgencyEquityCostIncludingHomeBuyAgentFee);
            readDocument.FullDisposalDate.Should().BeCloseTo(entity.FullDisposalDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.OriginalAgencyPercentage.Should().Be(entity.OriginalAgencyPercentage);
            readDocument.StaircasingPercentage.Should().Be(entity.StaircasingPercentage);
            readDocument.NewAgencyPercentage.Should().Be(entity.NewAgencyPercentage);
            readDocument.Invested.Should().Be(entity.Invested);
            readDocument.Month.Should().Be(entity.Month);
            readDocument.CalendarYear.Should().Be(entity.CalendarYear);
            readDocument.MMYYYY.Should().BeEquivalentTo(entity.MMYYYY);
            readDocument.Row.Should().Be(entity.Row);
            readDocument.Col.Should().Be(entity.Col);
            readDocument.HPIStart.Should().Be(entity.HPIStart);
            readDocument.HPIEnd.Should().Be(entity.HPIEnd);
            readDocument.HPIPlusMinus.Should().Be(entity.HPIPlusMinus);
            readDocument.AgencyPercentage.Should().Be(entity.AgencyPercentage);
            readDocument.MortgageEffect.Should().Be(entity.MortgageEffect);
            readDocument.RemainingAgencyCost.Should().Be(entity.RemainingAgencyCost);
            readDocument.WAEstimatedPropertyValue.Should().Be(entity.WAEstimatedPropertyValue);
            readDocument.AgencyFairValueDifference.Should().Be(entity.AgencyFairValueDifference);
            readDocument.ImpairmentProvision.Should().Be(entity.ImpairmentProvision);
            readDocument.FairValueReserve.Should().Be(entity.FairValueReserve);
            readDocument.AgencyFairValue.Should().Be(entity.AgencyFairValue);
            readDocument.DisposalsCost.Should().Be(entity.DisposalsCost);
            readDocument.DurationInMonths.Should().Be(entity.DurationInMonths);
            readDocument.MonthOfCompletionSinceSchemeStart.Should().Be(entity.MonthOfCompletionSinceSchemeStart);
            readDocument.DisposalMonthSinceCompletion.Should().Be(entity.DisposalMonthSinceCompletion);
            readDocument.IMSPaymentDate.Should().BeCloseTo(entity.IMSPaymentDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.IsPaid.Should().Be(entity.IsPaid);
            readDocument.IsAsset.Should().Be(entity.IsAsset);
            readDocument.PropertyType.Should().BeEquivalentTo(entity.PropertyType);
            readDocument.Tenure.Should().BeEquivalentTo(entity.Tenure);
            readDocument.ExpectedStaircasingRate.Should().Be(entity.ExpectedStaircasingRate);
            readDocument.EstimatedSalePrice.Should().Be(entity.EstimatedSalePrice);
            readDocument.RegionalSaleAdjust.Should().Be(entity.RegionalSaleAdjust);
            readDocument.RegionalStairAdjust.Should().Be(entity.RegionalStairAdjust);
            readDocument.NotLimitedByFirstCharge.Should().Be(entity.NotLimitedByFirstCharge);
            readDocument.EarlyMortgageIfNeverRepay.Should().Be(entity.EarlyMortgageIfNeverRepay);
            readDocument.ArrearsEffectAppliedOrLimited.Should().Be(entity.ArrearsEffectAppliedOrLimited);
            readDocument.RelativeSalePropertyTypeAndTenureAdjustment.Should().Be(entity.RelativeSalePropertyTypeAndTenureAdjustment);
            readDocument.RelativeStairPropertyTypeAndTenureAdjustment.Should().Be(entity.RelativeStairPropertyTypeAndTenureAdjustment);
            readDocument.IsLondon.Should().Be(entity.IsLondon);
            readDocument.QuarterSpend.Should().Be(entity.QuarterSpend);
            readDocument.MortgageProvider.Should().Be(entity.MortgageProvider);
            readDocument.HouseType.Should().Be(entity.HouseType);
            readDocument.PurchasePriceBand.Should().Be(entity.PurchasePriceBand);
            readDocument.HouseholdFiveKIncomeBand.Should().Be(entity.HouseholdFiveKIncomeBand);
            readDocument.HouseholdFiftyKIncomeBand.Should().Be(entity.HouseholdFiftyKIncomeBand);
            readDocument.FirstTimeBuyer.Should().Be(entity.FirstTimeBuyer);

            readDocument.HouseholdIncome.Should().Be(entity.HouseholdIncome);
            readDocument.EstimatedValuation.Should().Be(entity.EstimatedValuation);
        }

        /// <summary>
        /// Some database store Datetime Seconds fields to 6 decimal places instead of 7
        /// this helps compare the 2 entities in that case
        /// </summary>
        /// <param name="readDocument"></param>
        /// <param name="entity"></param>
        public static void AssetOutputModelIsEqual(this DocumentOutputModel readDocument, DocumentOutputModel entity)
        {
            readDocument.Id.Should().Be(entity.Id);
            readDocument.ModifiedDateTime.Should().BeCloseTo(entity.ModifiedDateTime, TimeSpan.FromMilliseconds(1.0));

            readDocument.Programme.Should().BeEquivalentTo(entity.Programme);
            readDocument.EquityOwner.Should().BeEquivalentTo(entity.EquityOwner);
            readDocument.SchemeId.Should().Be(entity.SchemeId);
            readDocument.LocationLaRegionName.Should().BeEquivalentTo(entity.LocationLaRegionName);
            readDocument.ImsOldRegion.Should().BeEquivalentTo(entity.ImsOldRegion);
            readDocument.NoOfBeds.Should().Be(entity.NoOfBeds);
            readDocument.Address.Should().BeEquivalentTo(entity.Address);
            readDocument.PropertyHouseName.Should().BeEquivalentTo(entity.PropertyHouseName);
            readDocument.PropertyStreetNumber.Should().BeEquivalentTo(entity.PropertyStreetNumber);
            readDocument.PropertyStreet.Should().BeEquivalentTo(entity.PropertyStreet);
            readDocument.PropertyTown.Should().BeEquivalentTo(entity.PropertyTown);
            readDocument.PropertyPostcode.Should().BeEquivalentTo(entity.PropertyPostcode);
            readDocument.DevelopingRslName.Should().BeEquivalentTo(entity.DevelopingRslName);
            readDocument.LBHA.Should().BeEquivalentTo(entity.LBHA);
            readDocument.CompletionDateForHpiStart.Should().BeCloseTo(entity.CompletionDateForHpiStart.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.ImsActualCompletionDate.Should().BeCloseTo(entity.ImsActualCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.ImsExpectedCompletionDate.Should().BeCloseTo(entity.ImsExpectedCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.ImsLegalCompletionDate.Should().BeCloseTo(entity.ImsLegalCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.HopCompletionDate.Should().BeCloseTo(entity.HopCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.Deposit.Should().Be(entity.Deposit);
            readDocument.AgencyEquityLoan.Should().Be(entity.AgencyEquityLoan);
            readDocument.DeveloperEquityLoan.Should().Be(entity.DeveloperEquityLoan);
            readDocument.ShareOfRestrictedEquity.Should().Be(entity.ShareOfRestrictedEquity);
            readDocument.DeveloperDiscount.Should().Be(entity.DeveloperDiscount);
            readDocument.Mortgage.Should().Be(entity.Mortgage);
            readDocument.PurchasePrice.Should().Be(entity.PurchasePrice);
            readDocument.Fees.Should().Be(entity.Fees);
            readDocument.HistoricUnallocatedFees.Should().Be(entity.HistoricUnallocatedFees);
            readDocument.ActualAgencyEquityCostIncludingHomeBuyAgentFee.Should().Be(entity.ActualAgencyEquityCostIncludingHomeBuyAgentFee);
            readDocument.FullDisposalDate.Should().BeCloseTo(entity.FullDisposalDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.OriginalAgencyPercentage.Should().Be(entity.OriginalAgencyPercentage);
            readDocument.StaircasingPercentage.Should().Be(entity.StaircasingPercentage);
            readDocument.NewAgencyPercentage.Should().Be(entity.NewAgencyPercentage);
            readDocument.Invested.Should().Be(entity.Invested);
            readDocument.Month.Should().Be(entity.Month);
            readDocument.CalendarYear.Should().Be(entity.CalendarYear);
            readDocument.MMYYYY.Should().BeEquivalentTo(entity.MMYYYY);
            readDocument.Row.Should().Be(entity.Row);
            readDocument.Col.Should().Be(entity.Col);
            readDocument.HPIStart.Should().Be(entity.HPIStart);
            readDocument.HPIEnd.Should().Be(entity.HPIEnd);
            readDocument.HPIPlusMinus.Should().Be(entity.HPIPlusMinus);
            readDocument.AgencyPercentage.Should().Be(entity.AgencyPercentage);
            readDocument.MortgageEffect.Should().Be(entity.MortgageEffect);
            readDocument.RemainingAgencyCost.Should().Be(entity.RemainingAgencyCost);
            readDocument.WAEstimatedPropertyValue.Should().Be(entity.WAEstimatedPropertyValue);
            readDocument.AgencyFairValueDifference.Should().Be(entity.AgencyFairValueDifference);
            readDocument.ImpairmentProvision.Should().Be(entity.ImpairmentProvision);
            readDocument.FairValueReserve.Should().Be(entity.FairValueReserve);
            readDocument.AgencyFairValue.Should().Be(entity.AgencyFairValue);
            readDocument.DisposalsCost.Should().Be(entity.DisposalsCost);
            readDocument.DurationInMonths.Should().Be(entity.DurationInMonths);
            readDocument.MonthOfCompletionSinceSchemeStart.Should().Be(entity.MonthOfCompletionSinceSchemeStart);
            readDocument.DisposalMonthSinceCompletion.Should().Be(entity.DisposalMonthSinceCompletion);
            readDocument.IMSPaymentDate.Should().BeCloseTo(entity.IMSPaymentDate.Value, TimeSpan.FromMilliseconds(1.0));
            readDocument.IsPaid.Should().Be(entity.IsPaid);
            readDocument.IsAsset.Should().Be(entity.IsAsset);
            readDocument.PropertyType.Should().BeEquivalentTo(entity.PropertyType);
            readDocument.Tenure.Should().BeEquivalentTo(entity.Tenure);
            readDocument.ExpectedStaircasingRate.Should().Be(entity.ExpectedStaircasingRate);
            readDocument.EstimatedSalePrice.Should().Be(entity.EstimatedSalePrice);
            readDocument.RegionalSaleAdjust.Should().Be(entity.RegionalSaleAdjust);
            readDocument.RegionalStairAdjust.Should().Be(entity.RegionalStairAdjust);
            readDocument.NotLimitedByFirstCharge.Should().Be(entity.NotLimitedByFirstCharge);
            readDocument.EarlyMortgageIfNeverRepay.Should().Be(entity.EarlyMortgageIfNeverRepay);
            readDocument.ArrearsEffectAppliedOrLimited.Should().Be(entity.ArrearsEffectAppliedOrLimited);
            readDocument.RelativeSalePropertyTypeAndTenureAdjustment.Should().Be(entity.RelativeSalePropertyTypeAndTenureAdjustment);
            readDocument.RelativeStairPropertyTypeAndTenureAdjustment.Should().Be(entity.RelativeStairPropertyTypeAndTenureAdjustment);
            readDocument.IsLondon.Should().Be(entity.IsLondon);
            readDocument.QuarterSpend.Should().Be(entity.QuarterSpend);
            readDocument.MortgageProvider.Should().Be(entity.MortgageProvider);
            readDocument.HouseType.Should().Be(entity.HouseType);
            readDocument.PurchasePriceBand.Should().Be(entity.PurchasePriceBand);
            readDocument.HouseholdFiveKIncomeBand.Should().Be(entity.HouseholdFiveKIncomeBand);
            readDocument.HouseholdFiftyKIncomeBand.Should().Be(entity.HouseholdFiftyKIncomeBand);
            readDocument.FirstTimeBuyer.Should().Be(entity.FirstTimeBuyer);

            readDocument.HouseholdIncome.Should().Be(entity.HouseholdIncome);
            readDocument.EstimatedValuation.Should().Be(entity.EstimatedValuation);
            readDocument.AssetRegisterVersionId.Should().Be(entity.AssetRegisterVersionId);
        }
    }
}
