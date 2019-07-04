using System;
using System.Collections.Generic;
using System.Linq;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using BV.PACS.Shared.Utils;
using NUnit.Framework;

namespace BV.Pacs.Tests.Server.Services
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
            SqlMapperEx.InitMappers();
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

            var sourceTracking = _trackingService.GetSourceTracking(new TrackingParameter(source.SourceId, "en")).Result;
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

            var list = _trackingService.GetSourceMaterials(new GridParameter(source.SourceId, "en")).Result.ToList();
            Assert.IsNotEmpty(list);

            Console.WriteLine($"received {list.Count} materials");
            var materialBarcodes = list.Select(m => m.MaterialBarcode);

            Console.WriteLine(string.Join(", ", materialBarcodes));
            Assert.Pass();
        }

        [Test]
        public void GetMaterialTrackingTest()
        {
            var condition = new AggregatedConditionDto {PageSize = 1};
            var items = _catalogService.GetMaterials(condition).Result.ToList();
            Assert.IsNotEmpty(items);
            var material = items[0];
            Console.WriteLine($"Found Material {material.MaterialBarcode} with ID {material.MaterialId}");

            var materialTracking = _trackingService.GetMaterialTracking(new TrackingParameter(material.MaterialId, "en")).Result;
            Assert.IsNotNull(materialTracking);

            Console.WriteLine(materialTracking);
            Assert.Pass();
        }

        [Test]
        public void GetAliquotTrackingTest()
        {
            var condition = new AggregatedConditionDto {PageSize = 1};
            var items = _catalogService.GetAliquots(condition).Result.ToList();
            Assert.IsNotEmpty(items);
            var aliquot = items[0];
            Console.WriteLine($"Found Aliquot {aliquot.AliquotBarcode} with ID {aliquot.AliquotId}");

            var aliquotTracking = _trackingService.GetAliquotTracking(new TrackingParameter(aliquot.AliquotId, "en")).Result;
            Assert.IsNotNull(aliquotTracking);

            Console.WriteLine(aliquotTracking);
            Assert.Pass();
        }

        [Test]
        public void GetTestTrackingTest()
        {
            var condition = new AggregatedConditionDto {PageSize = 1};
            var items = _catalogService.GetTests(condition).Result.ToList();
            Assert.IsNotEmpty(items);
            var test = items[0];
            Console.WriteLine($"Found Test {test.TestBarcode} with ID {test.TestId}");

            var testTracking = _trackingService.GetTestTracking(new TrackingParameter(test.TestId, "en")).Result;
            Assert.IsNotNull(testTracking);

            Console.WriteLine(testTracking);
            Assert.Pass();
        }

      
    }
}