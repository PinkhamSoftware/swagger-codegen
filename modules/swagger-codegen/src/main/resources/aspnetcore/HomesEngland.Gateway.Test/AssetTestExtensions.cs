using System;
using FluentAssertions;
using HomesEngland.Domain;

namespace HomesEngland.Gateway.Test
{
    public static class AssetTestExtensions
    {
        public static void AssetIsEqual(this IDocument readDocument, int id, IDocument entity)
        {
            readDocument.Id.Should().Be(id);
            //readAsset.ModifiedDateTime.Should().BeCloseTo(entity.ModifiedDateTime, TimeSpan.FromMilliseconds(1.0));

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
        }
    }
}
