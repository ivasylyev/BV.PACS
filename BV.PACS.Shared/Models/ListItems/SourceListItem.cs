using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    public class SourceListItem
    {
        [Column("idfSource")]
        public int SourceId { get; set; }

        [Column("idfsSourceType")]
        public string SourceTypeId { get; set; }

        [Column("datRegistration_Date")]
        public DateTime SourceRegistrationDate { get; set; }

        [Column("SourceType")]
        public string SourceType { get; set; }

        [Column("strPointOfOrigin")]
        public string SourcePointOfOrigin { get; set; }

        [Column("TemplateName")]
        public string SourceTemplateName { get; set; }

        [Column("intNmbrOfMaterials")]
        public string MaterialsAndAliquotsCount { get; set; }

        [Column("strNote")]
        public string SourceNote { get; set; }

        [Column("idfsCFormTemplateID")]
        public string SourceTemplateId { get; set; }

        [Column("idfsLogicalLockingStatus")]
        public string SourceLockingStatusId { get; set; }

        [Column("strBarcode")]
        public string SourceBarcode { get; set; }

        [Column("strMaterialType")]
        public string MaterialTypes { get; set; }

        [Column("strMaterialID")]
        public string MaterialBarcodes { get; set; }

        [Column("datCreationDate")]
        public DateTime SourceCreationDate { get; set; }

        [Column("idfsGeoLocation")]
        public string SourceGeoLocationId { get; set; }

        [Column("strAliquotID")]
        public string AliquotBarcodes { get; set; }

        [Column("strTestDate")]
        public string TestDates { get; set; }

        [Column("strTestTypeID")]
        public string TestTypes { get; set; }

        [Column("strTestResultID")]
        public string TestResults { get; set; }

        [Column("TestStatusId")]
        public string TestStatuses { get; set; }

        public override string ToString()
        {
            return $"Id:'{SourceBarcode}', Registered:'{SourceRegistrationDate}', Template:'{SourceTemplateName}'";
        }
    }
}