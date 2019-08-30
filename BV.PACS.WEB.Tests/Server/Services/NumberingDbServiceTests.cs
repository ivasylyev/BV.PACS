using System;
using System.Linq;
using BV.PACS.WEB.Server.Services;
using BV.PACS.WEB.Shared.Models;
using BV.PACS.WEB.Shared.Models.Parameters;
using NUnit.Framework;

namespace BV.PACS.WEB.Tests.Server.Services
{
    public class NumberingDbServiceTests
    {
        private NumberingDbService _service;


        [SetUp]
        public void Setup()
        {
            _service = new NumberingDbService(TestConfig.GetConfig());
        }

        [Test]
        public void GetSourceNumbersTest()
        {
            var enumIds = _service.GetNextNumbers(new NumberingParameter(NumberingObject.SourceBarcode, 1)).Result;
            Assert.IsNotNull(enumIds);
            var ids = enumIds.ToList();
            Assert.AreEqual(1, ids.Count);
            var id = ids[0];
            Assert.IsNotEmpty(id);

            Console.WriteLine(id);
            Assert.Pass();
        }

        [Test]
        public void GetMaterialsNumbersTest()
        {
            var enumIds = _service.GetNextNumbers(new NumberingParameter(NumberingObject.MaterialNumber, 2)).Result;
            Assert.IsNotNull(enumIds);
            var ids = enumIds.ToList();
            Assert.AreEqual(2, ids.Count);
            var id = ids[0];
            Assert.IsNotEmpty(id);

            Console.WriteLine(id);
            Assert.Pass();
        }
    }
}