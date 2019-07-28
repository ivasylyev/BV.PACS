using System;

namespace BV.PACS.WEB.Shared.Models
{
    // ReSharper disable once InconsistentNaming
    public class SourceCatalogDto
    {
        [GetColumn("idfSource")]
        public int SourceId { get; set; }

        [GetColumn("idfsSourceType")]
        public string SourceTypeId { get; set; }

        [GetColumn("datRegistration_Date")]
        public DateTime SourceRegistrationDate { get; set; }

        [GetColumn("SourceType")]
        public string SourceType { get; set; }

        [GetColumn("strPointOfOrigin")]
        public string SourcePointOfOrigin { get; set; }

        [GetColumn("TemplateName")]
        public string SourceTemplateName { get; set; }

        [GetColumn("intNmbrOfMaterials")]
        public string MaterialsAndAliquotsCount { get; set; }

        [GetColumn("strNote")]
        public string SourceNote { get; set; }

        [GetColumn("idfsCFormTemplateID")]
        public string SourceTemplateId { get; set; }

        [GetColumn("idfsLogicalLockingStatus")]
        public string SourceLockingStatusId { get; set; }

        [GetColumn("strBarcode")]
        public string SourceBarcode { get; set; }

        [GetColumn("strMaterialType")]
        public string MaterialTypes { get; set; }

        [GetColumn("strMaterialID")]
        public string MaterialBarcodes { get; set; }

        [GetColumn("datCreationDate")]
        public DateTime SourceCreationDate { get; set; }

        [GetColumn("idfsGeoLocation")]
        public string SourceGeoLocationId { get; set; }

        [GetColumn("strAliquotID")]
        public string AliquotBarcodes { get; set; }

        [GetColumn("strTestDate")]
        public string TestDates { get; set; }

        [GetColumn("strTestTypeID")]
        public string TestTypes { get; set; }

        [GetColumn("strTestResultID")]
        public string TestResults { get; set; }

        [GetColumn("TestStatusId")]
        public string TestStatuses { get; set; }

        public static SourceCatalogDto CreateEmptyItem(string defValue)
        {
            return new SourceCatalogDto
            {
                SourceCreationDate = DateTime.Now,
                SourceTypeId = defValue,
                SourceType = defValue,
                SourcePointOfOrigin = defValue,
                SourceTemplateName = defValue,
                MaterialsAndAliquotsCount = defValue,
                SourceNote = defValue,
                SourceTemplateId = defValue,
                SourceLockingStatusId = defValue,
                SourceBarcode = defValue,
                MaterialTypes = defValue,
                MaterialBarcodes = defValue,
                SourceGeoLocationId = defValue,
                AliquotBarcodes = defValue,
                TestDates = defValue,
                TestTypes = defValue,
                TestResults = defValue,
                TestStatuses = defValue
            };
        }

        public override string ToString()
        {
            return $"Id:'{SourceBarcode}', Registered:'{SourceRegistrationDate}', Template:'{SourceTemplateName}'";
        }
    }
}