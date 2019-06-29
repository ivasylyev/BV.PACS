using System;
using System.Linq;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using NUnit.Framework;

namespace BV.Pacs.Tests
{
    public class DbServiceTests
    {
        private DbService _service;
        private CatalogDbService _catalogService;

        [SetUp]
        public void Setup()
        {
            _service = new DbService();
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

            var sourceTracking = _service.GetSourceTracking(new TrackingParameter(source.SourceId, "en"));
            Assert.IsNotNull(sourceTracking);

            Console.WriteLine(sourceTracking);
            Assert.Pass();
        }


        [Test]
        public void GetSourceTemplatesTest()
        {
            var templates = _service.GetTemplates(new TemplateLookupParameter(FormTypes.Source, "en")).ToList();
            Assert.IsNotEmpty(templates);
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Name == "Default for source"));
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Id == "fftSource"));

            Assert.Pass();
        }

        [Test]
        public void GetMaterialTemplatesTest()
        {
            var templates = _service.GetTemplates(new TemplateLookupParameter(FormTypes.Material, "en")).ToList();
            Assert.IsNotEmpty(templates);
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Name == "Default for material"));
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Id == "fftStrain"));

            Assert.Pass();
        }

        [Test]
        public void GetAliquotTemplatesTest()
        {
            var templates = _service.GetTemplates(new TemplateLookupParameter(FormTypes.Aliquot, "en")).ToList();
            Assert.IsNotEmpty(templates);
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Name == "Default for aliquot"));
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Id == "fftAliquot"));

            Assert.Pass();
        }

        [Test]
        public void GetTestTemplatesTest()
        {
            var templates = _service.GetTemplates(new TemplateLookupParameter(FormTypes.Test, "en")).ToList();
            Assert.IsNotEmpty(templates);
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Name == "Default for test"));
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Id == "fftTest"));

            Assert.Pass();
        }

        [Test]
        public void GetTestTypesTest()
        {
            var list = _service.GetLookup(new BaseLookupParameter(BaseLookupTables.rftTestType, "en")).ToList();
            Assert.IsNotEmpty(list);

            Assert.Pass();
        }

        [Test]
        public void GetTestResultTest()
        {
            var list = _service.GetLookup(new BaseLookupParameter(BaseLookupTables.rftTestResult, "en")).ToList();
            Assert.IsNotEmpty(list);

            Assert.Pass();
        }

        [Test]
        public void GetTestStatusTest()
        {
            var list = _service.GetLookup(new BaseLookupParameter(BaseLookupTables.rftTestStatus, "en")).ToList();
            Assert.IsNotEmpty(list);

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

            var list = _service.GetSourceMaterials(new GridParameter(source.SourceId, "en")).ToList();
            Assert.IsNotEmpty(list);

            Console.WriteLine($"received {list.Count} materials");
            var materialBarcodes = list.Select(m => m.MaterialBarcode);

            Console.WriteLine(string.Join(", ", materialBarcodes));
            Assert.Pass();
        }
    }
}