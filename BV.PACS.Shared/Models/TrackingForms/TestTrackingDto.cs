using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [GetDataUrl("api/Tracking/GetTest")]
    [PostDataUrl("api/Tracking/PostTest")]
    public class TestTrackingDto
    {
        [Column("idfTest")]
        public int TestId { get; set; }

        [Column("idfsTestType")]
        public string TestTypeId { get; set; }

        [Column("datTestDate")]
        public DateTime TestDate { get; set; }

        [Column("idfsTestResult")]
        public string TestResultId { get; set; }

        [Column("idfsCFormTemplateID")]
        public string TestTemplateId { get; set; }

        [Column("TemplateName")]
        public string TestTemplateName { get; set; }

        [Column("strBarcode")]
        public string TestBarcode { get; set; }

        [Column("strNote")]
        public string TestNote { get; set; }

        [Column("datRegistration_Date")]
        public DateTime TestRegistrationDate { get; set; }

        [Column("idfsTestStatus")]
        public string TestStatusId { get; set; }

        [Column("idfContainer")]
        public string AliquotId { get; set; }


        [Column("strSourceBarcode")]
        public string SourceBarcode { get; set; }

        [Column("strContainerBarcode")]
        public string AliquotBarcode { get; set; }


        [Column("idfsMaterialType")]
        public string MaterialTypeId { get; set; }


        [Column("TestType")]
        public string TestType { get; set; }

        [Column("TestResult")]
        public string TestResult { get; set; }

        [Column("TestStatus")]
        public string TestStatus { get; set; }


        [Column("idfsTestSet")]
        public string TestSetId { get; set; }

        [Column("idfSource")]
        public string SourceId { get; set; }


        [Column("strMaterialBarcode")]
        public string MaterialBarcode { get; set; }

        [Column("idfMaterial")]
        public string MaterialId { get; set; }


        public override string ToString()
        {
            return $"Id:'{TestBarcode}', Registered:'{TestRegistrationDate}', Template:'{TestTemplateName}'";
        }
    }
}