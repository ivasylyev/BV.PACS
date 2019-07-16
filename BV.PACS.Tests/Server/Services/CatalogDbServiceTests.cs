using System;
using System.Linq;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using BV.PACS.Tests;
using NUnit.Framework;

namespace BV.Pacs.Tests.Server.Services
{
    public class CatalogDbServiceTests
    {
        private CatalogDbService _service;

        [SetUp]
        public void Setup()
        {
            _service = new CatalogDbService(TestConfig.GetConfig());
            SqlMapperEx.InitMappers();
        }

        [Test]
        public void GetSourcesTest()
        {
            var condition = new AggregatedConditionDto();
            var items = _service.GetSources(condition).Result.ToList();
            Assert.IsNotEmpty(items);

            Console.WriteLine(items[0]);
            Assert.Pass();
        }

        [Test]
        public void GetSourcesRecordCountTest()
        {
            var condition = new AggregatedConditionDto();
            var count = _service.GetSourcesRecordCount(condition).Result;
            Assert.IsTrue(count > 0);

            Console.WriteLine($"Total sources: {count}");
            Assert.Pass();
        }

        [Test]
        public void GetMaterialsTest()
        {
            var condition = new AggregatedConditionDto();
            var items = _service.GetMaterials(condition).Result.ToList();
            Assert.IsNotEmpty(items);

            Console.WriteLine(items[0]);
            Assert.Pass();
        }

        [Test]
        public void GetMaterialsRecordCountTest()
        {
            var condition = new AggregatedConditionDto();
            var count = _service.GetMaterialsRecordCount(condition).Result;
            Assert.IsTrue(count > 0);

            Console.WriteLine($"Total Materials: {count}");
            Assert.Pass();
        }

        [Test]
        public void GetAliquotsTest()
        {
            var condition = new AggregatedConditionDto();
            var items = _service.GetAliquots(condition).Result.ToList();
            Assert.IsNotEmpty(items);

            Console.WriteLine(items[0]);
            Assert.Pass();
        }

        [Test]
        public void GetAliquotsRecordCountTest()
        {
            var condition = new AggregatedConditionDto();
            var count = _service.GetAliquotsRecordCount(condition).Result;
            Assert.IsTrue(count > 0);

            Console.WriteLine($"Total Aliquots: {count}");
            Assert.Pass();
        }

        [Test]
        public void GetTestsTest()
        {
            var condition = new AggregatedConditionDto();
            var items = _service.GetTests(condition).Result.ToList();
            Assert.IsNotEmpty(items);

            Console.WriteLine(items[0]);
            Assert.Pass();
        }

        [Test]
        public void GetTestsRecordCountTest()
        {
            var condition = new AggregatedConditionDto();
            var count = _service.GetTestsRecordCount(condition).Result;
            Assert.IsTrue(count > 0);

            Console.WriteLine($"Total Tests: {count}");
            Assert.Pass();
        }
    }
}