using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [GetDataUrl("api/Tracking/GetMaterial")]
    [PostDataUrl("api/Tracking/PostMaterial")]
    public class MaterialTrackingDto
    {

        [GetColumn("idfMaterial")]
        public int MaterialId { get; set; }

        [GetColumn("idfsCFormTemplateID")]
        public string MaterialTemplateId { get; set; }

        [GetColumn("strBarcode")]
        public string MaterialBarcode { get; set; }

        [GetColumn("strNote")]
        public string MaterialNote { get; set; }

        [GetColumn("idfsMaterialTypeID")]
        public string MaterialTypeId { get; set; }

        [GetColumn("MaterialType")]
        public string MaterialType { get; set; }


        [GetColumn("TemplateName")]
        public string MaterialTemplateName { get; set; }

        [GetColumn("idfOwner")]
        public int MaterialOwnerId { get; set; }

        [GetColumn("Owner")]
        public string MaterialOwnerName { get; set; }

        [GetColumn("idfSource")]
        public int SourceId { get; set; }

        [GetColumn("datRegistration_Date")]
        public DateTime MaterialRegistrationDate { get; set; }

        [GetColumn("ParentMaterialNumber")]
        public string ParentMaterialBarcode { get; set; }

        [GetColumn("ParentMaterial")]
        public int ParentMaterialId { get; set; }

        [GetColumn("SourceBarcode")]
        public string SourceBarcode { get; set; }

        [GetColumn("Location")]
        public string MaterialPointOfOrigin { get; set; }

        [GetColumn("Isolation_idfGeoLocation")]
        public int AddressGeoLocationId { get; set; }

        [GetColumn("idfsGeoLocation")]
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