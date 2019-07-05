using System;
using System.Linq;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using NUnit.Framework;

namespace BV.Pacs.Tests.Server.Services
{
    public class TrackingDbServiceTests
    {
        private TrackingDbService _trackingService;
        private CatalogDbService _catalogService;


        private Lazy<SourceCatalogDto> SourceWithMaterial => new Lazy<SourceCatalogDto>(GetSourceWithMaterial);
        private Lazy<MaterialCatalogDto> Material => new Lazy<MaterialCatalogDto>(GetMaterial);

        private Lazy<AliquotCatalogDto> Aliquot => new Lazy<AliquotCatalogDto>(GetAliquot);

        private Lazy<TestCatalogDto> Test => new Lazy<TestCatalogDto>(GetTest);

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
            var sourceTracking = _trackingService.GetSourceTracking(new TrackingParameter(SourceWithMaterial.Value.SourceId, "en")).Result;
            Assert.IsNotNull(sourceTracking);

            Console.WriteLine(sourceTracking);
            Assert.Pass();
        }

        [Test]
        public void GetSourceMaterialsTest()
        {
            var list = _trackingService.GetSourceMaterials(new GridParameter(SourceWithMaterial.Value.SourceId, "en")).Result.ToList();
            Assert.IsNotEmpty(list);

            Console.WriteLine($"received {list.Count} materials");
            var materialBarCodes = list.Select(m => m.MaterialBarcode);

            Console.WriteLine(string.Join(", ", materialBarCodes));
            Assert.Pass();
        }

        [Test]
        public void GetSourceDiagnosticsTest()
        {
            var list = _trackingService.GetSourceDiagnostics(new GridParameter(SourceWithMaterial.Value.SourceId, "en")).Result.ToList();
          // todo: select non-empty diagnostics here
            Assert.Pass();
        }


        [Test]
        public void GetSourceTestsTest()
        {
            var list = _trackingService.GetSourceTests(new GridParameter(SourceWithMaterial.Value.SourceId, "en")).Result.ToList();
            Assert.IsNotEmpty(list);

            Console.WriteLine($"received {list.Count} tests");
            var testBarCodes = list.Select(m => m.MaterialBarcode);

            Console.WriteLine(string.Join(", ", testBarCodes));
            Assert.Pass();
        }

        [Test]
        public void GetMaterialTrackingTest()
        {
            var materialTracking = _trackingService.GetMaterialTracking(new TrackingParameter(Material.Value.MaterialId, "en")).Result;
            Assert.IsNotNull(materialTracking);

            Console.WriteLine(materialTracking);
            Assert.Pass();
        }


        [Test]
        public void GetAliquotTrackingTest()
        {
            var aliquotTracking = _trackingService.GetAliquotTracking(new TrackingParameter(Aliquot.Value.AliquotId, "en")).Result;
            Assert.IsNotNull(aliquotTracking);

            Console.WriteLine(aliquotTracking);
            Assert.Pass();
        }

        [Test]
        public void GetAliquotTestsTest()
        {
            var list = _trackingService.GetAliquotTests(new GridParameter(Aliquot.Value.AliquotId, "en")).Result.ToList();
            Assert.IsNotEmpty(list);

            Console.WriteLine($"received {list.Count} tests");
            var testBarCodes = list.Select(m => m.MaterialBarcode);

            Console.WriteLine(string.Join(", ", testBarCodes));
            Assert.Pass();
        }


        [Test]
        public void GetTestTrackingTest()
        {
            var testTracking = _trackingService.GetTestTracking(new TrackingParameter(Test.Value.TestId, "en")).Result;
            Assert.IsNotNull(testTracking);

            Console.WriteLine(testTracking);
            Assert.Pass();
        }

        [Test]
        public void GetSourceAuditTest()
        {
            var list = _trackingService.GetSourceAudit(new GridParameter(SourceWithMaterial.Value.SourceId, "en")).Result.ToList();
            Assert.IsNotEmpty(list);
            Console.WriteLine($"received {list.Count} audit records");
         
            Assert.Pass();
        }

        [Test]
        public void GetMaterialAuditTest()
        {
            var list = _trackingService.GetMaterialAudit(new GridParameter(Material.Value.MaterialId, "en")).Result.ToList();
            Assert.IsNotEmpty(list);
            Console.WriteLine($"received {list.Count} audit records");

            Assert.Pass();
        }
        [Test]
        public void GetAliquotAuditTest()
        {
            var list = _trackingService.GetAliquotAudit(new GridParameter(Aliquot.Value.AliquotId, "en")).Result.ToList();
            Assert.IsNotEmpty(list);
            Console.WriteLine($"received {list.Count} audit records");

            Assert.Pass();
        }
        [Test]
        public void GetTestAuditTest()
        {
            var list = _trackingService.GetTestAudit(new GridParameter(Test.Value.TestId, "en")).Result.ToList();
            Assert.IsNotEmpty(list);
            Console.WriteLine($"received {list.Count} audit records");

            Assert.Pass();
        }

        private SourceCatalogDto GetSourceWithMaterial()
        {
            var condition = new AggregatedConditionDto {PageSize = 1};
            condition.AddStandardConditionIfNotEmpty("strMaterialBarcode", "m", Operators.LikeOperator);
            var items = _catalogService.GetSources(condition).Result.ToList();
            Assert.IsNotEmpty(items);
            var source = items[0];
            Console.WriteLine($"Found source {source.SourceBarcode} with ID {source.SourceId}");
            return source;
        }

        private MaterialCatalogDto GetMaterial()
        {
            var condition = new AggregatedConditionDto {PageSize = 1};
            var items = _catalogService.GetMaterials(condition).Result.ToList();
            Assert.IsNotEmpty(items);
            var material = items[0];
            Console.WriteLine($"Found Material {material.MaterialBarcode} with ID {material.MaterialId}");
            return material;
        }

        private AliquotCatalogDto GetAliquot()
        {
            var condition = new AggregatedConditionDto {PageSize = 1};
            var items = _catalogService.GetAliquots(condition).Result.ToList();
            Assert.IsNotEmpty(items);
            var aliquot = items[0];
            Console.WriteLine($"Found Aliquot {aliquot.AliquotBarcode} with ID {aliquot.AliquotId}");
            return aliquot;
        }

        private TestCatalogDto GetTest()
        {
            var condition = new AggregatedConditionDto {PageSize = 1};
            var items = _catalogService.GetTests(condition).Result.ToList();
            Assert.IsNotEmpty(items);
            var test = items[0];
            Console.WriteLine($"Found Test {test.TestBarcode} with ID {test.TestId}");
            return test;
        }
    }
}