using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [GetDataUrl("api/Tracking/GetSource")]
    [PostDataUrl("api/Tracking/PostSource")]
    public class SourceTrackingDto
    {

        [Column("idfSource")]
        public int SourceId { get; set; }

        [Column("idfsCFormTemplateID")]
        public string SourceTemplateId { get; set; }

        [Column("strBarcode")]
        public string SourceBarcode { get; set; }

        [Column("strNote")]
        public string SourceNote { get; set; }

        [Column("idfsSourceType")]
        public string SourceTypeId { get; set; }

        [Column("idfOwner")]
        public int OwnerId { get; set; }

        [Column("SourceType")]
        public string SourceType { get; set; }

        [Column("strSourceTypeShortName")]
        public string SourceTypeShort { get; set; }

        [Column("datRegistration_Date")]
        public DateTime SourceRegistrationDate { get; set; }

        [Column("strLocationDesription")]
        public string GeoLocationDescription { get; set; }

        [Column("idfsGeoLocation")]
        public string GeoLocationId { get; set; }

        [Column("Source_idfGeoLocation")]
        public string AddressGeoLocationId { get; set; }


        [Column("TemplateName")]
        public string SourceTemplateName { get; set; }

        [Column("Location")]
        public string SourcePointOfOrigin { get; set; }


        public override string ToString()
        {
            return $"Id:'{SourceBarcode}', Registered:'{SourceRegistrationDate}', Template:'{SourceTemplateName}'";
        }
    }
}