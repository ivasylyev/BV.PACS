using System;
using System.Linq;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using NUnit.Framework;

namespace Tests
{
    public class DbServiceTests
    {
        private DbService _service;

        [SetUp]
        public void Setup()
        {
            _service = new DbService();
        }

        [Test]
        public void GetSourcesTest()
        {
            var condition = new AggregatedConditionDto();
            var items = _service.GetSources(condition).ToList();
            Assert.IsNotEmpty(items);

            Console.WriteLine(items[0]);
            Assert.Pass();
        }

        [Test]
        public void GetSourcesRecordCountTest()
        {
            var condition = new AggregatedConditionDto();
            var count = _service.GetSourcesRecordCount(condition);
            Assert.IsTrue(count > 0);

            Console.WriteLine($"Total sources: {count}");
            Assert.Pass();
        }

        [Test]
        public void GetMaterialsTest()
        {
            var condition = new AggregatedConditionDto();
            var items = _service.GetMaterials(condition).ToList();
            Assert.IsNotEmpty(items);

            Console.WriteLine(items[0]);
            Assert.Pass();
        }

        [Test]
        public void GetMaterialsRecordCountTest()
        {
            var condition = new AggregatedConditionDto();
            var count = _service.GetMaterialsRecordCount(condition);
            Assert.IsTrue(count > 0);

            Console.WriteLine($"Total Materials: {count}");
            Assert.Pass();
        }

        [Test]
        public void GetAliquotsTest()
        {
            var condition = new AggregatedConditionDto();
            var items = _service.GetAliquots(condition).ToList();
            Assert.IsNotEmpty(items);

            Console.WriteLine(items[0]);
            Assert.Pass();
        }

        [Test]
        public void GetAliquotsRecordCountTest()
        {
            var condition = new AggregatedConditionDto();
            var count = _service.GetAliquotsRecordCount(condition);
            Assert.IsTrue(count > 0);

            Console.WriteLine($"Total Aliquots: {count}");
            Assert.Pass();
        }

        [Test]
        public void GetTestsTest()
        {
            var condition = new AggregatedConditionDto();
            var items = _service.GetTests(condition).ToList();
            Assert.IsNotEmpty(items);

            Console.WriteLine(items[0]);
            Assert.Pass();
        }

        [Test]
        public void GetTestsRecordCountTest()
        {
            var condition = new AggregatedConditionDto();
            var count = _service.GetTestsRecordCount(condition);
            Assert.IsTrue(count > 0);

            Console.WriteLine($"Total Tests: {count}");
            Assert.Pass();
        }


        [Test]
        public void GetSourceTemplatesTest()
        {
            var templates = _service.GetTemplates(FormTypes.Source, "en").ToList();
            Assert.IsNotEmpty(templates);
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Name == "Default for source"));
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Id == "fftSource"));

            Assert.Pass();
        }

        [Test]
        public void GetMaterialTemplatesTest()
        {
            var templates = _service.GetTemplates(FormTypes.Material, "en").ToList();
            Assert.IsNotEmpty(templates);
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Name == "Default for material"));
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Id == "fftStrain"));

            Assert.Pass();
        }

        [Test]
        public void GetAliquotTemplatesTest()
        {
            var templates = _service.GetTemplates(FormTypes.Aliquot, "en").ToList();
            Assert.IsNotEmpty(templates);
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Name == "Default for aliquot"));
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Id == "fftAliquot"));

            Assert.Pass();
        }

        [Test]
        public void GetTestTemplatesTest()
        {
            var templates = _service.GetTemplates(FormTypes.Test, "en").ToList();
            Assert.IsNotEmpty(templates);
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Name == "Default for test"));
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Id == "fftTest"));

            Assert.Pass();
        }

        [Test]
        public void GetTestTypesTest()
        {
            var list = _service.GetLookup(new LookupParameter(BaseLookupTables.rftTestType, "en")).ToList();
            Assert.IsNotEmpty(list);
  
            Assert.Pass();
        }

        [Test]
        public void GetTestResultTest()
        {
            var list = _service.GetLookup(new LookupParameter(BaseLookupTables.rftTestResult, "en")).ToList();
            Assert.IsNotEmpty(list);

            Assert.Pass();
        }

        [Test]
        public void GetTestStatusTest()
        {
            var list = _service.GetLookup(new LookupParameter(BaseLookupTables.rftTestStatus, "en")).ToList();
            Assert.IsNotEmpty(list);

            Assert.Pass();
        }
    }
}