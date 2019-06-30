using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [DataUrl("api/Tracking/GetMaterial")]
    public class MaterialTrackingDto
    {

        [Column("idfMaterial")]
        public int MaterialId { get; set; }

        [Column("idfsCFormTemplateID")]
        public string MaterialTemplateId { get; set; }

        [Column("strBarcode")]
        public string MaterialBarcode { get; set; }

        [Column("strNote")]
        public string MaterialNote { get; set; }

        [Column("idfsMaterialTypeID")]
        public string MaterialTypeId { get; set; }

        [Column("MaterialType")]
        public string MaterialType { get; set; }


        [Column("TemplateName")]
        public string MaterialTemplateName { get; set; }

        [Column("idfOwner")]
        public int MaterialOwnerId { get; set; }

        [Column("Owner")]
        public string MaterialOwnerName { get; set; }

        [Column("idfSource")]
        public int SourceId { get; set; }

        [Column("datRegistration_Date")]
        public DateTime MaterialRegistrationDate { get; set; }

        [Column("ParentMaterialNumber")]
        public string ParentMaterialBarcode { get; set; }

        [Column("ParentMaterial")]
        public int ParentMaterialId { get; set; }

        [Column("SourceBarcode")]
        public string SourceBarcode { get; set; }

        [Column("Location")]
        public string MaterialPointOfOrigin { get; set; }

        [Column("Isolation_idfGeoLocation")]
        public int AddressGeoLocationId { get; set; }

        [Column("idfsGeoLocation")]
        public int GeoLocationId { get; set; }

        [Column("idfsGeoLocationNew")]
        public int GeoLocationNewId { get; set; }

        [Column("strCultureShortName")]
        public string MaterialTypeShort { get; set; }
       
        public override string ToString()
        {
            return $"Id:'{MaterialBarcode}', Registered:'{MaterialRegistrationDate}', Template:'{MaterialTemplateName}'";
        }
    }
}