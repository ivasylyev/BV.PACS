using System.Linq;
using BV.PACS.WEB.Server.Services;
using BV.PACS.WEB.Shared.Models;
using BV.PACS.WEB.Shared.Models.Parameters;
using BV.PACS.WEB.Tests;
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
    }
}