using BV.PACS.Client.Services.Api;
using BV.PACS.Shared.Models;
using NUnit.Framework;

namespace BV.PACS.Tests.Client.Services.Api
{
    public class UrlMappingServiceTests
    {
        private UrlMappingService _service;

        [SetUp]
        public void Setup()
        {
            _service = new UrlMappingService();
        }

        [Test]
        public void GetLookupUrlTest()
        {
            var url = _service.GetLookupUrl<TemplateLookupItem>();
            Assert.AreEqual("api/Lookup/GetTemplatesLookup", url);

            url = _service.GetLookupUrl<BaseLookupItem>();
            Assert.AreEqual("api/Lookup/GetLookup", url);
            Assert.Pass();
        }

        [Test]
        public void GetCatalogDataUrlTest()
        {
            var url = _service.GetCatalogDataUrl<SourceCatalogDto>();
            Assert.AreEqual("api/Catalog/GetSources", url);
            url = _service.GetCatalogDataUrl<MaterialCatalogDto>();
            Assert.AreEqual("api/Catalog/GetMaterials", url);
            url = _service.GetCatalogDataUrl<AliquotCatalogDto>();
            Assert.AreEqual("api/Catalog/GetAliquots", url);
            url = _service.GetCatalogDataUrl<TestCatalogDto>();
            Assert.AreEqual("api/Catalog/GetTests", url);
            Assert.Pass();
        }

        [Test]
        public void GetCatalogCountUrlTest()
        {
            var url = _service.GetCatalogCountUrl<SourceCatalogDto>();
            Assert.AreEqual("api/Catalog/GetSourcesRecordCount", url);
            url = _service.GetCatalogCountUrl<MaterialCatalogDto>();
            Assert.AreEqual("api/Catalog/GetMaterialsRecordCount", url);
            url = _service.GetCatalogCountUrl<AliquotCatalogDto>();
            Assert.AreEqual("api/Catalog/GetAliquotsRecordCount", url);
            url = _service.GetCatalogCountUrl<TestCatalogDto>();
            Assert.AreEqual("api/Catalog/GetTestsRecordCount", url);
            Assert.Pass();
        }
    }
}