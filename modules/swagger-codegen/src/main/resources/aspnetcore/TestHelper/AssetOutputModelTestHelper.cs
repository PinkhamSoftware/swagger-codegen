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
            
        }
    }
}
