using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [GetDataUrl("api/Catalog/GetTests")]
    [GetCountUrl("api/Catalog/GetTestsRecordCount")]
    public class TestCatalogDto
    {
        [Column("idfTest")]
        public int TestId { get; set; }

        [Column("idfsTestType")]
        public string TestTypeId { get; set; }

        [Column("datTestDate")]
        public DateTime TestDate { get; set; }

        [Column("idfsTestResult")]
        public string TestResultId { get; set; }

        [Column("datRegistration_Date")]
        public DateTime TestRegistrationDate { get; set; }

        [Column("idfsTestStatus")]
        public string TestStatusId { get; set; }

        [Column("idfContainer")]
        public string AliquotId { get; set; }

        [Column("strContainerNumber")]
        public string AliquotBarcode { get; set; }

        [Column("idfsMaterialType")]
        public string MaterialTypeId { get; set; }

        [Column("strMaterialNumber")]
        public string MaterialBarcode { get; set; }

        [Column("idfsCFormTemplateID")]
        public string TestTemplateId { get; set; }

        [Column("strSourceNumber")]
        public string SourceBarcode { get; set; }

        [Column("SourceName")]
        public string SourceType { get; set; }

        [Column("MaterialType")]
        public string MaterialType { get; set; }

        [Column("TestType")]
        public string TestType { get; set; }

        [Column("TestResult")]
        public string TestResult { get; set; }

        [Column("TestStatus")]
        public string TestStatus { get; set; }

        [Column("TemplateName")]
        public string TestTemplateName { get; set; }

        [Column("LocationPath")]
        public string LocationPath { get; set; }

        [Column("LogicalLockingStatus")]
        public string TestLockingStatusId { get; set; }

        [Column("strBarcode")]
        public string TestBarcode { get; set; }

        public override string ToString()
        {
            return $"Id:'{TestBarcode}', Registered:'{TestRegistrationDate}', Template:'{TestTemplateName}'";
        }
    }
}