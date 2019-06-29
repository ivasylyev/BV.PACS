using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [DataUrl("api/Tracking/GetSource")]
    public class SourceTrackingDto
    {
        /*

	
	[Source].idfAddress_GeoLocation AS 'Source_idfGeoLocation',
	s_addr.idfsGeoLocation,
	s_addr.strLocationDesription,

	SourceType_List.strShortName as 'strSourceTypeShortName',
	TemplateNameRef.[Name] AS 'TemplateName',

	s_ggl.strLevelGeoLocationPath as 'Location'
         */
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
        public string LocationPath { get; set; }


        public override string ToString()
        {
            return $"Id:'{SourceBarcode}', Registered:'{SourceRegistrationDate}', Template:'{SourceTemplateName}'";
        }
    }
}