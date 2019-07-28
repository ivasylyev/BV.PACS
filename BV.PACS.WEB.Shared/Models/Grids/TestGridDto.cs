using System;

namespace BV.PACS.WEB.Shared.Models
{
    public abstract class TestGridDto
    {
        [GetColumn("idfTest")]
        public int TestId { get; set; }

        [GetColumn("strTestNumber")]
        public string TestBarcode { get; set; }

        [GetColumn("strContainerNumber")]
        public string AliquotBarcode { get; set; }


        [GetColumn("strMaterialNumber")]
        public string MaterialBarcode { get; set; }

        [GetColumn("strSourceNumber")]
        public string SourceBarcode { get; set; }

        [GetColumn("datRegistration_Date")]
        public DateTime? TestRegistrationDate { get; set; }

        [GetColumn("datTestDate")]
        public DateTime? TestDate { get; set; }

        [GetColumn("MaterialType")]
        public string MaterialType { get; set; }

        [GetColumn("TestType")]
        public string TestType { get; set; }
        [GetColumn("TestResult")]
        public string TestResult { get; set; }

        [GetColumn("TestStatus")]
        public string TestStatus { get; set; }

        [GetColumn("TestSet")]
        public string TestSet { get; set; }

        [GetColumn("strPerformedByName")]
        public string PerformedByName { get; set; }


        [GetColumn("strValidatedByName")]
        public string ValidatedByName { get; set; }

        [GetColumn("idfsCFormTemplateID")]
        public string TestTemplateId { get; set; }

        [GetColumn("TemplateName")]
        public string TestTemplateName { get; set; }

    }
}