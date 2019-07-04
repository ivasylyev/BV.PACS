using System;

namespace BV.PACS.Shared.Models
{

    [StoredProcedures("dbo.spTest_SelectDetail", "dbo.spTest_Post", "idfTest")]
    public class TestTrackingDto
    {
        [GetColumn("idfTest")]
        [PostColumn("idfTest")]
        public int TestId { get; set; }

        [GetColumn("idfsTestType")]
        [PostColumn("idfsTestType")]
        public string TestTypeId { get; set; }

        [GetColumn("datTestDate")]
        [PostColumn("datTestDate")]
        public DateTime? TestDate { get; set; }

        [GetColumn("idfsTestResult")]
        public string TestResultId { get; set; }

        [GetColumn("idfsCFormTemplateID")]
        [PostColumn("idfsCFormTemplateID")]
        public string TestTemplateId { get; set; }

        [GetColumn("TemplateName")]
        public string TestTemplateName { get; set; }

        [GetColumn("strBarcode")]
        [PostColumn("strBarcode")]
        public string TestBarcode { get; set; }

        [GetColumn("strNote")]
        [PostColumn("strNote")]
        public string TestNote { get; set; }

        [GetColumn("datRegistration_Date")]
        [PostColumn("datRegistration_Date")]
        public DateTime TestRegistrationDate { get; set; }

        [GetColumn("idfsTestStatus")]
        [PostColumn("idfsTestStatus")]
        public string TestStatusId { get; set; }

        [GetColumn("idfContainer")]
        [PostColumn("idfContainer")]
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
        [PostColumn("idfsTestSet")]
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