using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [GetDataUrl("api/Catalog/GetTests")]
    [GetCountUrl("api/Catalog/GetTestsRecordCount")]
    public class TestCatalogDto
    {
        [GetColumn("idfTest")]
        public int TestId { get; set; }

        [GetColumn("idfsTestType")]
        public string TestTypeId { get; set; }

        [GetColumn("datTestDate")]
        public DateTime TestDate { get; set; }

        [GetColumn("idfsTestResult")]
        public string TestResultId { get; set; }

        [GetColumn("datRegistration_Date")]
        public DateTime TestRegistrationDate { get; set; }

        [GetColumn("idfsTestStatus")]
        public string TestStatusId { get; set; }

        [GetColumn("idfContainer")]
        public string AliquotId { get; set; }

        [GetColumn("strContainerNumber")]
        public string AliquotBarcode { get; set; }

        [GetColumn("idfsMaterialType")]
        public string MaterialTypeId { get; set; }

        [GetColumn("strMaterialNumber")]
        public string MaterialBarcode { get; set; }

        [GetColumn("idfsCFormTemplateID")]
        public string TestTemplateId { get; set; }

        [GetColumn("strSourceNumber")]
        public string SourceBarcode { get; set; }

        [GetColumn("SourceName")]
        public string SourceType { get; set; }

        [GetColumn("MaterialType")]
        public string MaterialType { get; set; }

        [GetColumn("TestType")]
        public string TestType { get; set; }

        [GetColumn("TestResult")]
        public string TestResult { get; set; }

        [GetColumn("TestStatus")]
        public string TestStatus { get; set; }

        [GetColumn("TemplateName")]
        public string TestTemplateName { get; set; }

        [GetColumn("LocationPath")]
        public string LocationPath { get; set; }

        [GetColumn("LogicalLockingStatus")]
        public string TestLockingStatusId { get; set; }

        [GetColumn("strBarcode")]
        public string TestBarcode { get; set; }

        public override string ToString()
        {
            return $"Id:'{TestBarcode}', Registered:'{TestRegistrationDate}', Template:'{TestTemplateName}'";
        }
    }
}