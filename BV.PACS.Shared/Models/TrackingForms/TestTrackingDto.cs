using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [GetDataUrl("api/Tracking/GetTest")]
    [PostDataUrl("api/Tracking/PostTest")]
    public class TestTrackingDto
    {
        [GetColumn("idfTest")]
        public int TestId { get; set; }

        [GetColumn("idfsTestType")]
        public string TestTypeId { get; set; }

        [GetColumn("datTestDate")]
        public DateTime TestDate { get; set; }

        [GetColumn("idfsTestResult")]
        public string TestResultId { get; set; }

        [GetColumn("idfsCFormTemplateID")]
        public string TestTemplateId { get; set; }

        [GetColumn("TemplateName")]
        public string TestTemplateName { get; set; }

        [GetColumn("strBarcode")]
        public string TestBarcode { get; set; }

        [GetColumn("strNote")]
        public string TestNote { get; set; }

        [GetColumn("datRegistration_Date")]
        public DateTime TestRegistrationDate { get; set; }

        [GetColumn("idfsTestStatus")]
        public string TestStatusId { get; set; }

        [GetColumn("idfContainer")]
        public string AliquotId { get; set; }


        [GetColumn("strSourceBarcode")]
        public string SourceBarcode { get; set; }

        [GetColumn("strContainerBarcode")]
        public string AliquotBarcode { get; set; }


        [GetColumn("idfsMaterialType")]
        public string MaterialTypeId { get; set; }


        [GetColumn("TestType")]
        public string TestType { get; set; }

        [GetColumn("TestResult")]
        public string TestResult { get; set; }

        [GetColumn("TestStatus")]
        public string TestStatus { get; set; }


        [GetColumn("idfsTestSet")]
        public string TestSetId { get; set; }

        [GetColumn("idfSource")]
        public string SourceId { get; set; }


        [GetColumn("strMaterialBarcode")]
        public string MaterialBarcode { get; set; }

        [GetColumn("idfMaterial")]
        public string MaterialId { get; set; }


        public override string ToString()
        {
            return $"Id:'{TestBarcode}', Registered:'{TestRegistrationDate}', Template:'{TestTemplateName}'";
        }
    }
}