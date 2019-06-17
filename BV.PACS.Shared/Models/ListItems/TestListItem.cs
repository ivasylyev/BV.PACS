using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    public class TestListItem
    {
        [Column("idfTest")]
        public int TestId { get; set; }

        [Column("idfsTestTypeID")]
        public string TestTypeId { get; set; }

        [Column("datRegistration_Date")]
        public DateTime TestRegistrationDate { get; set; }

        [Column("AllowDelete")]
        public bool AllowDelete { get; set; }

        [Column("TestType")]
        public string TestType { get; set; }

        [Column("LogicalLockingStatus")]
        public string TestLockingStatusId { get; set; }

        [Column("strBarcode")]
        public string TestBarcode { get; set; }

        [Column("SourceName")]
        public string SourceName { get; set; }

        [Column("TemplateName")]
        public string TestTemplateName { get; set; }

        [Column("strNote")]
        public string TestNote { get; set; }

        [Column("idfsCFormTemplateID")]
        public string TestTemplateId { get; set; }

        [Column("intNmbrOfContainers")]
        public string AliquotsCount { get; set; }

        [Column("strSourceNumber")]
        public string SourceBarcode { get; set; }

        [Column("strOwnerName")]
        public string TestOwnerName { get; set; }

        [Column("strAliquotID")]
        public string Aliquots { get; set; }

        [Column("strPointOfOrigin")]
        public string TestPointOfOrigin { get; set; }


        public override string ToString()
        {
            return $"Id:'{TestBarcode}', Registered:'{TestRegistrationDate}', Template:'{TestTemplateName}'";
        }
    }
}