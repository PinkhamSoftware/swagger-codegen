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

            
        }

        /// <summary>
        /// Some database store Datetime Seconds fields to 6 decimal places instead of 7
        /// this helps compare the 2 entities in that case
        /// </summary>
        /// <param name="readDocument"></param>
        /// <param name="entity"></param>
        public static bool AssetIsEqual(this IDocument readDocument, CreateDocumentRequest entity)
        {
            //todo implement comparison?
            return
                false;
        }

        /// <summary>
        /// Some database store Datetime Seconds fields to 6 decimal places instead of 7
        /// this helps compare the 2 entities in that case
        /// </summary>
        /// <param name="readDocument"></param>
        /// <param name="entity"></param>
        public static void AssetOutputModelIsEqual(this DocumentOutputModel readDocument, CreateDocumentRequest entity)
        {
            //todo implement comparison
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

            //todo implement comparison
        }
    }
}
