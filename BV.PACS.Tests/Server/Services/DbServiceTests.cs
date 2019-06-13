using System;
using System.Linq;
using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
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
            AggregatedConditionDto condition = new AggregatedConditionDto();
            var items = _service.GetSources(condition).ToList();
            Assert.IsNotEmpty(items);

            Console.WriteLine(items[0]);
            Assert.Pass();
        }

        [Test]
        public void GetSourcesRecordCountTest()
        {
            AggregatedConditionDto condition = new AggregatedConditionDto();
            var count = _service.GetSourcesRecordCount(condition);
            Assert.IsTrue(count>0);

            Console.WriteLine($"Total sources: {count}");
            Assert.Pass();
        }
    }
}