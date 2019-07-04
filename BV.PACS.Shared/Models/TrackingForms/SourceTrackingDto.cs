using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
 
    [StoredProcedures("dbo.spSource_SelectDetail", "dbo.spSource_Post", "idfSource")]
    public class SourceTrackingDto
    {

        [GetColumn("idfSource")]
        [PostColumn("idfSource")]
        public int SourceId { get; set; }

        [GetColumn("idfsCFormTemplateID")]
        [PostColumn("idfsCFormTemplateID")]
        public string SourceTemplateId { get; set; }

        [GetColumn("strBarcode")]
        [PostColumn("strBarcode")]
        public string SourceBarcode { get; set; }

        [GetColumn("strNote")]
        [PostColumn("strNote")]
        public string SourceNote { get; set; }

        [GetColumn("idfsSourceType")]
        [PostColumn("idfsSourceType")]
        public string SourceTypeId { get; set; }

        [GetColumn("idfOwner")]
        [PostColumn("idfOwner")]
        public int? OwnerId { get; set; }

        [GetColumn("SourceType")]
        public string SourceType { get; set; }

        [GetColumn("strSourceTypeShortName")]
        public string SourceTypeShort { get; set; }

        [GetColumn("datRegistration_Date")]
        [PostColumn("datRegistration_Date")]
        public DateTime SourceRegistrationDate { get; set; }

        [GetColumn("strLocationDesription")]
        [PostColumn("strLocationDesription")]
        public string GeoLocationDescription { get; set; }

        [GetColumn("idfsGeoLocation")]
        [PostColumn("idfsGeoLocation")]
        public string GeoLocationId { get; set; }

        [GetColumn("Source_idfGeoLocation")]
        [PostColumn("Source_idfGeoLocation")]
        public string AddressGeoLocationId { get; set; }


        [GetColumn("TemplateName")]
        public string SourceTemplateName { get; set; }

        [GetColumn("Location")]
        public string SourcePointOfOrigin { get; set; }


        public override string ToString()
        {
            return $"Id:'{SourceBarcode}', Registered:'{SourceRegistrationDate}', Template:'{SourceTemplateName}'";
        }
    }
}