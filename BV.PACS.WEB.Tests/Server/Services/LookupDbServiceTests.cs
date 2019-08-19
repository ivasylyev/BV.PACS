using System.Linq;
using BV.PACS.WEB.Server.Services;
using BV.PACS.WEB.Shared.Models;
using BV.PACS.WEB.Shared.Models.Parameters;
using NUnit.Framework;

namespace BV.PACS.WEB.Tests.Server.Services
{
    public class LookupDbServiceTests
    {
        private LookupDbService _service;


        [SetUp]
        public void Setup()
        {
            _service = new LookupDbService(TestConfig.GetConfig());
            SqlMapperEx.InitMappers();
        }


        [Test]
        public void GetSourceTemplatesTest()
        {
            var templates = _service.GetTemplates(new TemplateLookupParameter(FormTypes.Source, "en")).Result.ToList();
            Assert.IsNotEmpty(templates);
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Name == "Default for source"));
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Id == "fftSource"));

            Assert.Pass();
        }

        [Test]
        public void GetMaterialTemplatesTest()
        {
            var templates = _service.GetTemplates(new TemplateLookupParameter(FormTypes.Material, "en")).Result.ToList();
            Assert.IsNotEmpty(templates);
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Name == "Default for material"));
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Id == "fftStrain"));

            Assert.Pass();
        }

        [Test]
        public void GetAliquotTemplatesTest()
        {
            var templates = _service.GetTemplates(new TemplateLookupParameter(FormTypes.Aliquot, "en")).Result.ToList();
            Assert.IsNotEmpty(templates);
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Name == "Default for aliquot"));
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Id == "fftAliquot"));

            Assert.Pass();
        }

        [Test]
        public void GetTestTemplatesTest()
        {
            var templates = _service.GetTemplates(new TemplateLookupParameter(FormTypes.Test, "en")).Result.ToList();
            Assert.IsNotEmpty(templates);
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Name == "Default for test"));
            Assert.IsNotNull(templates.FirstOrDefault(t => t.Id == "fftTest"));

            Assert.Pass();
        }

        [Test]
        public void GetTestTypesTest()
        {
            var list = _service.GetLookup(new BaseLookupParameter(BaseLookupTables.rftTestType, "en")).Result.ToList();
            Assert.IsNotEmpty(list);

            Assert.Pass();
        }

        [Test]
        public void GetTestResultTest()
        {
            var list = _service.GetLookup(new BaseLookupParameter(BaseLookupTables.rftTestResult, "en")).Result.ToList();
            Assert.IsNotEmpty(list);

            Assert.Pass();
        }

        [Test]
        public void GetTestStatusTest()
        {
            var list = _service.GetLookup(new BaseLookupParameter(BaseLookupTables.rftTestStatus, "en")).Result.ToList();
            Assert.IsNotEmpty(list);

            Assert.Pass();
        }

        [Test]
        public void GetMaterialTypesTest()
        {
            var list = _service.GetSourceMaterialTypes(new SourceMaterialTypeLookupParameter(SourceMaterialTypeLookupParameter.Material, "en")).Result.ToList();
            var bacteria = list.FirstOrDefault(t => t.Id == "ctnBacteria");
            Assert.IsNotNull(bacteria);
            Assert.AreEqual("rootMaterialTypeTreeNode", bacteria.ParentId);
            Assert.AreEqual("Bacteria", bacteria.Name);
            Assert.AreEqual(1, bacteria.Level);
            Assert.AreEqual("rftMaterialTypeTreeNode", bacteria.ReferenceType);
            Assert.IsNotEmpty(list);

            Assert.Pass();
        }
        [Test]
        public void GetSourceTypesTest()
        {
            var list = _service.GetSourceMaterialTypes(new SourceMaterialTypeLookupParameter(SourceMaterialTypeLookupParameter.Source, "en")).Result.ToList();
            var animals = list.FirstOrDefault(t => t.Id == "srnAnimals");
            Assert.IsNotNull(animals);
            Assert.AreEqual("rootSourceTypeTreeNode", animals.ParentId);
            Assert.AreEqual("Animals", animals.Name);
            Assert.AreEqual(1, animals.Level);
            Assert.AreEqual("rftSourceTypeTreeNode", animals.ReferenceType);
            Assert.IsNotEmpty(list);

            Assert.Pass();
        }

    }
}