using System;

namespace BV.PACS.WEB.Shared.Models
{
    [StoredProcedures("dbo.spStrainPassport_SelectDetail", "dbo.spStrainPassport", "idfMaterial")]
    public class MaterialTrackingDto
    {
        [GetColumn("idfMaterial")]
        [PostColumn("idfMaterial")]
        public int MaterialId { get; set; }

        [GetColumn("idfsCFormTemplateID")]
        [PostColumn("idfsCFormTemplateID")]
        public string MaterialTemplateId { get; set; }

        [GetColumn("strBarcode")]
        [PostColumn("strBarcode")]
        public string MaterialBarcode { get; set; }

        [GetColumn("strNote")]
        [PostColumn("strNote")]
        public string MaterialNote { get; set; }

        [GetColumn("idfsMaterialType")]
        [PostColumn("idfsMaterialType")]
        public string MaterialTypeId { get; set; }

        [GetColumn("MaterialType")]
        public string MaterialType { get; set; }


        [GetColumn("strLocationDesription")]
        [PostColumn("strLocationDesription")]
        public string LocationDesription { get; set; }

        [GetColumn("TemplateName")]
        public string MaterialTemplateName { get; set; }

        [GetColumn("idfOwner")]
        [PostColumn("idfOwner")]
        public int? MaterialOwnerId { get; set; }

        [GetColumn("Owner")]
        public string MaterialOwnerName { get; set; }

        [GetColumn("idfSource")]
        [PostColumn("idfSource")]
        public int? SourceId { get; set; }

        [GetColumn("datRegistration_Date")]
        [PostColumn("datRegistration_Date")]
        public DateTime MaterialRegistrationDate { get; set; }

        [GetColumn("ParentMaterialNumber")]
        public string ParentMaterialBarcode { get; set; }

        [GetColumn("ParentMaterial")]
        [PostColumn("ParentMaterial")]
        public int? ParentMaterialId { get; set; }

        [GetColumn("SourceBarcode")]
        public string SourceBarcode { get; set; }

        [GetColumn("Location")]
        public string MaterialPointOfOrigin { get; set; }

        [GetColumn("Isolation_idfGeoLocation")]
        [PostColumn("Isolation_idfGeoLocation")]
        public int? AddressGeoLocationId { get; set; }

        [GetColumn("idfsGeoLocation")]
        [PostColumn("idfsGeoLocation")]
        public string GeoLocationId { get; set; }

        [GetColumn("idfsGeoLocationNew")]
        public string GeoLocationNewId { get; set; }

        [GetColumn("strCultureShortName")]
        public string MaterialTypeShort { get; set; }

        public override string ToString()
        {
            return $"Id:'{MaterialBarcode}', Registered:'{MaterialRegistrationDate}', Template:'{MaterialTemplateName}'";
        }
    }
}