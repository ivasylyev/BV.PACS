using System;
using System.Linq;
using BV.PACS.Server.Services;
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
            var items = _service.GetSources().ToList();
            Assert.IsNotEmpty(items);

            Console.WriteLine(items[0]);
            Assert.Pass();
        }
    }
}