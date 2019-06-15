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
        [Test]
        public void GetMaterialsTest()
        {
            AggregatedConditionDto condition = new AggregatedConditionDto();
            var items = _service.GetMaterials(condition).ToList();
            Assert.IsNotEmpty(items);

            Console.WriteLine(items[0]);
            Assert.Pass();
        }

        [Test]
        public void GetMaterialsRecordCountTest()
        {
            AggregatedConditionDto condition = new AggregatedConditionDto();
            var count = _service.GetMaterialsRecordCount(condition);
            Assert.IsTrue(count > 0);

            Console.WriteLine($"Total Materials: {count}");
            Assert.Pass();
        }

        [Test]
        public void GetSourceTemplatesTest()
        {
           
            var templates = _service.GetTemplates(FormTypes.Source, "en").ToList();
            Assert.IsNotEmpty(templates);
            Assert.IsNotNull(templates.FirstOrDefault(t=>t.Name=="Default for source"));
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
    }
}