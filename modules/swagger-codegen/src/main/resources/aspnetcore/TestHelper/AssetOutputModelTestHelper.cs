using System;
using FluentAssertions;
using HomesEngland.UseCase.CreateAsset.Models;
using HomesEngland.UseCase.GetDocument.Models;

namespace TestHelper
{
    public static class AssetOutputModelTestHelper
    {
        /// <summary>
        /// Some database store Datetime Seconds fields to 6 decimal places instead of 7
        /// this helps compare the 2 entities in that case
        /// </summary>
        /// <param name="documentOutputModel"></param>
        /// <param name="entity"></param>
        public static void AssetOutputModelIsEqual(this CreateDocumentRequest documentOutputModel, DocumentOutputModel entity)
        {
            documentOutputModel.Programme.Should().BeEquivalentTo(entity.Programme);
            documentOutputModel.EquityOwner.Should().BeEquivalentTo(entity.EquityOwner);
            documentOutputModel.SchemeId.Should().Be(entity.SchemeId);
            documentOutputModel.LocationLaRegionName.Should().BeEquivalentTo(entity.LocationLaRegionName);
            documentOutputModel.ImsOldRegion.Should().BeEquivalentTo(entity.ImsOldRegion);
            documentOutputModel.NoOfBeds.Should().Be(entity.NoOfBeds);
            documentOutputModel.Address.Should().BeEquivalentTo(entity.Address);
            documentOutputModel.PropertyHouseName.Should().BeEquivalentTo(entity.PropertyHouseName);
            documentOutputModel.PropertyStreetNumber.Should().BeEquivalentTo(entity.PropertyStreetNumber);
            documentOutputModel.PropertyStreet.Should().BeEquivalentTo(entity.PropertyStreet);
            documentOutputModel.PropertyTown.Should().BeEquivalentTo(entity.PropertyTown);
            documentOutputModel.PropertyPostcode.Should().BeEquivalentTo(entity.PropertyPostcode);
            documentOutputModel.DevelopingRslName.Should().BeEquivalentTo(entity.DevelopingRslName);
            documentOutputModel.LBHA.Should().BeEquivalentTo(entity.LBHA);
            documentOutputModel.CompletionDateForHpiStart.Should().BeCloseTo(entity.CompletionDateForHpiStart.Value, TimeSpan.FromMilliseconds(1.0));
            documentOutputModel.ImsActualCompletionDate.Should().BeCloseTo(entity.ImsActualCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            documentOutputModel.ImsExpectedCompletionDate.Should().BeCloseTo(entity.ImsExpectedCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            documentOutputModel.ImsLegalCompletionDate.Should().BeCloseTo(entity.ImsLegalCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            documentOutputModel.HopCompletionDate.Should().BeCloseTo(entity.HopCompletionDate.Value, TimeSpan.FromMilliseconds(1.0));
            documentOutputModel.Deposit.Should().Be(entity.Deposit);
            documentOutputModel.AgencyEquityLoan.Should().Be(entity.AgencyEquityLoan);
            documentOutputModel.DeveloperEquityLoan.Should().Be(entity.DeveloperEquityLoan);
            documentOutputModel.ShareOfRestrictedEquity.Should().Be(entity.ShareOfRestrictedEquity);
            documentOutputModel.DeveloperDiscount.Should().Be(entity.DeveloperDiscount);
            documentOutputModel.Mortgage.Should().Be(entity.Mortgage);
            documentOutputModel.PurchasePrice.Should().Be(entity.PurchasePrice);
            documentOutputModel.Fees.Should().Be(entity.Fees);
            documentOutputModel.HistoricUnallocatedFees.Should().Be(entity.HistoricUnallocatedFees);
            documentOutputModel.ActualAgencyEquityCostIncludingHomeBuyAgentFee.Should().Be(entity.ActualAgencyEquityCostIncludingHomeBuyAgentFee);
            documentOutputModel.FullDisposalDate.Should().BeCloseTo(entity.FullDisposalDate.Value, TimeSpan.FromMilliseconds(1.0));
            documentOutputModel.OriginalAgencyPercentage.Should().Be(entity.OriginalAgencyPercentage);
            documentOutputModel.StaircasingPercentage.Should().Be(entity.StaircasingPercentage);
            documentOutputModel.NewAgencyPercentage.Should().Be(entity.NewAgencyPercentage);
            documentOutputModel.Invested.Should().Be(entity.Invested);
            documentOutputModel.Month.Should().Be(entity.Month);
            documentOutputModel.CalendarYear.Should().Be(entity.CalendarYear);
            documentOutputModel.MMYYYY.Should().BeEquivalentTo(entity.MMYYYY);
            documentOutputModel.Row.Should().Be(entity.Row);
            documentOutputModel.Col.Should().Be(entity.Col);
            documentOutputModel.HPIStart.Should().Be(entity.HPIStart);
            documentOutputModel.HPIEnd.Should().Be(entity.HPIEnd);
            documentOutputModel.HPIPlusMinus.Should().Be(entity.HPIPlusMinus);
            documentOutputModel.AgencyPercentage.Should().Be(entity.AgencyPercentage);
            documentOutputModel.MortgageEffect.Should().Be(entity.MortgageEffect);
            documentOutputModel.RemainingAgencyCost.Should().Be(entity.RemainingAgencyCost);
            documentOutputModel.WAEstimatedPropertyValue.Should().Be(entity.WAEstimatedPropertyValue);
            documentOutputModel.AgencyFairValueDifference.Should().Be(entity.AgencyFairValueDifference);
            documentOutputModel.ImpairmentProvision.Should().Be(entity.ImpairmentProvision);
            documentOutputModel.FairValueReserve.Should().Be(entity.FairValueReserve);
            documentOutputModel.AgencyFairValue.Should().Be(entity.AgencyFairValue);
            documentOutputModel.DisposalsCost.Should().Be(entity.DisposalsCost);
            documentOutputModel.DurationInMonths.Should().Be(entity.DurationInMonths);
            documentOutputModel.MonthOfCompletionSinceSchemeStart.Should().Be(entity.MonthOfCompletionSinceSchemeStart);
            documentOutputModel.DisposalMonthSinceCompletion.Should().Be(entity.DisposalMonthSinceCompletion);
            documentOutputModel.IMSPaymentDate.Should().BeCloseTo(entity.IMSPaymentDate.Value, TimeSpan.FromMilliseconds(1.0));
            documentOutputModel.IsPaid.Should().Be(entity.IsPaid);
            documentOutputModel.IsAsset.Should().Be(entity.IsAsset);
            documentOutputModel.PropertyType.Should().BeEquivalentTo(entity.PropertyType);
            documentOutputModel.Tenure.Should().BeEquivalentTo(entity.Tenure);
            documentOutputModel.ExpectedStaircasingRate.Should().Be(entity.ExpectedStaircasingRate);
            documentOutputModel.EstimatedSalePrice.Should().Be(entity.EstimatedSalePrice);
            documentOutputModel.RegionalSaleAdjust.Should().Be(entity.RegionalSaleAdjust);
            documentOutputModel.RegionalStairAdjust.Should().Be(entity.RegionalStairAdjust);
            documentOutputModel.NotLimitedByFirstCharge.Should().Be(entity.NotLimitedByFirstCharge);
            documentOutputModel.EarlyMortgageIfNeverRepay.Should().Be(entity.EarlyMortgageIfNeverRepay);
            documentOutputModel.ArrearsEffectAppliedOrLimited.Should().Be(entity.ArrearsEffectAppliedOrLimited);
            documentOutputModel.RelativeSalePropertyTypeAndTenureAdjustment.Should().Be(entity.RelativeSalePropertyTypeAndTenureAdjustment);
            documentOutputModel.RelativeStairPropertyTypeAndTenureAdjustment.Should().Be(entity.RelativeStairPropertyTypeAndTenureAdjustment);
            documentOutputModel.IsLondon.Should().Be(entity.IsLondon);
            documentOutputModel.QuarterSpend.Should().Be(entity.QuarterSpend);
            documentOutputModel.MortgageProvider.Should().Be(entity.MortgageProvider);
            documentOutputModel.HouseType.Should().Be(entity.HouseType);
            documentOutputModel.PurchasePriceBand.Should().Be(entity.PurchasePriceBand);
            documentOutputModel.HouseholdFiveKIncomeBand.Should().Be(entity.HouseholdFiveKIncomeBand);
            documentOutputModel.HouseholdFiftyKIncomeBand.Should().Be(entity.HouseholdFiftyKIncomeBand);
            documentOutputModel.FirstTimeBuyer.Should().Be(entity.FirstTimeBuyer);

            documentOutputModel.HouseholdIncome.Should().Be(entity.HouseholdIncome);
            documentOutputModel.EstimatedValuation.Should().Be(entity.EstimatedValuation);
        }
    }
}
