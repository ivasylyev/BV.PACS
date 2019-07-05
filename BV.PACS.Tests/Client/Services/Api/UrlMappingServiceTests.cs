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
            var url = _service.LookupUrl<TemplateLookupItem>();
            Assert.AreEqual("api/Lookup/GetTemplatesLookup", url);

            url = _service.LookupUrl<BaseLookupItem>();
            Assert.AreEqual("api/Lookup/GetLookup", url);

            url = _service.LookupUrl<string>();
            Assert.AreEqual(string.Empty, url);

            Assert.Pass();
        }

        [Test]
        public void GetCatalogDataUrlTest()
        {
            var url = _service.CatalogDataUrl<SourceCatalogDto>();
            Assert.AreEqual("api/Catalog/GetSources", url);
            url = _service.CatalogDataUrl<MaterialCatalogDto>();
            Assert.AreEqual("api/Catalog/GetMaterials", url);
            url = _service.CatalogDataUrl<AliquotCatalogDto>();
            Assert.AreEqual("api/Catalog/GetAliquots", url);
            url = _service.CatalogDataUrl<TestCatalogDto>();
            Assert.AreEqual("api/Catalog/GetTests", url);

            url = _service.CatalogDataUrl<string>();
            Assert.AreEqual(string.Empty, url);

            Assert.Pass();
        }

        [Test]
        public void GetCatalogCountUrlTest()
        {
            var url = _service.CatalogCountUrl<SourceCatalogDto>();
            Assert.AreEqual("api/Catalog/GetSourcesRecordCount", url);
            url = _service.CatalogCountUrl<MaterialCatalogDto>();
            Assert.AreEqual("api/Catalog/GetMaterialsRecordCount", url);
            url = _service.CatalogCountUrl<AliquotCatalogDto>();
            Assert.AreEqual("api/Catalog/GetAliquotsRecordCount", url);
            url = _service.CatalogCountUrl<TestCatalogDto>();
            Assert.AreEqual("api/Catalog/GetTestsRecordCount", url);
            url = _service.CatalogCountUrl<string>();
            Assert.AreEqual(string.Empty, url);
            Assert.Pass();
        }


        [Test]
        public void GetTrackingUrlTest()
        {
            var url = _service.GetTrackingUrl<SourceTrackingDto>();
            Assert.AreEqual("api/Tracking/GetSource", url);
            url = _service.GetTrackingUrl<MaterialTrackingDto>();
            Assert.AreEqual("api/Tracking/GetMaterial", url);
            url = _service.GetTrackingUrl<AliquotTrackingDto>();
            Assert.AreEqual("api/Tracking/GetAliquot", url);
            url = _service.GetTrackingUrl<TestTrackingDto>();
            Assert.AreEqual("api/Tracking/GetTest", url);

            url = _service.GetTrackingUrl<string>();
            Assert.AreEqual(string.Empty, url);

            Assert.Pass();
        }


        [Test]
        public void PostTrackingUrlTest()
        {
            var url = _service.PostTrackingUrl<SourceTrackingDto>();
            Assert.AreEqual("api/Tracking/PostSource", url);
            url = _service.PostTrackingUrl<MaterialTrackingDto>();
            Assert.AreEqual("api/Tracking/PostMaterial", url);
            url = _service.PostTrackingUrl<AliquotTrackingDto>();
            Assert.AreEqual("api/Tracking/PostAliquot", url);
            url = _service.PostTrackingUrl<TestTrackingDto>();
            Assert.AreEqual("api/Tracking/PostTest", url);

            url = _service.PostTrackingUrl<string>();
            Assert.AreEqual(string.Empty, url);

            Assert.Pass();
        }

        [Test]
        public void GetGridUrlTest()
        {
            var url = _service.GridUrl<MaterialGridDto>();
            Assert.AreEqual("api/Grid/GetSourceMaterials", url);
            url = _service.GridUrl<SourceTestGridDto>();
            Assert.AreEqual("api/Grid/GetSourceTests", url);
            url = _service.GridUrl<AliquotTestGridDto>();
            Assert.AreEqual("api/Grid/GetAliquotTests", url);

            url = _service.GridUrl<string>();
            Assert.AreEqual(string.Empty, url);

            Assert.Pass();
        }
    }
}