using System;
using System.Linq;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using NUnit.Framework;

namespace BV.Pacs.Tests
{
    public class TrackingDbServiceTests
    {
        private TrackingDbService _trackingService;
        private CatalogDbService _catalogService;

        [SetUp]
        public void Setup()
        {
            _trackingService = new TrackingDbService();
            _catalogService = new CatalogDbService();
        }


        [Test]
        public void GetSourceTrackingTest()
        {
            var condition = new AggregatedConditionDto {PageSize = 1};
            condition.AddStandardConditionIfNotEmpty("strMaterialBarcode", "m", Operators.LikeOperator);
            var items = _catalogService.GetSources(condition).Result.ToList();
            Assert.IsNotEmpty(items);
            var source = items[0];
            Console.WriteLine($"Found source {source.SourceBarcode} with ID {source.SourceId}");

            var sourceTracking = _trackingService.GetSourceTracking(new TrackingParameter(source.SourceId, "en"));
            Assert.IsNotNull(sourceTracking);

            Console.WriteLine(sourceTracking);
            Assert.Pass();
        }


        [Test]
        public void GetSourceMaterialsTest()
        {
            var condition = new AggregatedConditionDto();
            condition.AddStandardConditionIfNotEmpty("strMaterialBarcode", "m", Operators.LikeOperator);
            var items = _catalogService.GetSources(condition).Result.ToList();
            Assert.IsNotEmpty(items);
            var source = items[0];
            Console.WriteLine($"Found source {source.SourceBarcode} with ID {source.SourceId}");

            var list = _trackingService.GetSourceMaterials(new GridParameter(source.SourceId, "en")).ToList();
            Assert.IsNotEmpty(list);

            Console.WriteLine($"received {list.Count} materials");
            var materialBarcodes = list.Select(m => m.MaterialBarcode);

            Console.WriteLine(string.Join(", ", materialBarcodes));
            Assert.Pass();
        }
    }
}