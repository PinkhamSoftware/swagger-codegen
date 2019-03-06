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
        }
    }
}
