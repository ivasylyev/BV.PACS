using BV.PACS.Server.Services;
using BV.PACS.Shared.Models;
using NUnit.Framework;

namespace BV.Pacs.Tests.Server.Services
{
    public class SqlMapperExTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void StoredProceduresMappingTest()
        {
            Assert.IsNotNull(SqlMapperEx.GetStoredProcedureAttribute<SourceTrackingDto>());
            Assert.IsNotNull(SqlMapperEx.GetStoredProcedureAttribute<MaterialTrackingDto>());
            Assert.IsNotNull(SqlMapperEx.GetStoredProcedureAttribute<AliquotTrackingDto>());
            Assert.IsNotNull(SqlMapperEx.GetStoredProcedureAttribute<TestTrackingDto>());
        }

        [Test]
        public void SourceTrackingMappingTest()
        {
            var mapping = SqlMapperEx.GetMapping<SourceTrackingDto>();
            Assert.IsNotEmpty(mapping);
            Assert.IsTrue(mapping.ContainsValue("idfSource"));
            Assert.IsTrue(mapping.ContainsValue("strBarcode"));
            Assert.IsTrue(mapping.ContainsValue("datRegistration_Date"));
            Assert.IsTrue(mapping.ContainsValue("idfsCFormTemplateID"));
            Assert.IsTrue(mapping.ContainsValue("strNote"));
            Assert.IsTrue(mapping.ContainsValue("idfsSourceType"));
            Assert.IsTrue(mapping.ContainsValue("idfsGeoLocation"));
            Assert.IsTrue(mapping.ContainsValue("idfOwner"));
            Assert.IsTrue(mapping.ContainsValue("Source_idfGeoLocation"));
            Assert.IsTrue(mapping.ContainsValue("strLocationDesription"));


            Assert.Pass();
        }

        [Test]
        public void MaterialTrackingMappingTest()
        {
            var mapping = SqlMapperEx.GetMapping<MaterialTrackingDto>();
            Assert.IsNotEmpty(mapping);
            Assert.IsTrue(mapping.ContainsValue("idfMaterial"));
            Assert.IsTrue(mapping.ContainsValue("strBarcode"));
            Assert.IsTrue(mapping.ContainsValue("idfsMaterialType"));
            Assert.IsTrue(mapping.ContainsValue("idfsCFormTemplateID"));
            Assert.IsTrue(mapping.ContainsValue("strNote"));
            Assert.IsTrue(mapping.ContainsValue("ParentMaterial"));
            Assert.IsTrue(mapping.ContainsValue("datRegistration_Date"));
            Assert.IsTrue(mapping.ContainsValue("Isolation_idfGeoLocation"));
            Assert.IsTrue(mapping.ContainsValue("idfsGeoLocation"));
            Assert.IsTrue(mapping.ContainsValue("strLocationDesription"));

            Assert.IsTrue(mapping.ContainsValue("idfOwner"));

            Assert.IsTrue(mapping.ContainsValue("idfSource"));
            Assert.IsTrue(mapping.ContainsValue("ParentMaterialBarcode"));
            Assert.IsTrue(mapping.ContainsValue("LastUsedAliquotNumber"));


            Assert.Pass();
        }
    }
}