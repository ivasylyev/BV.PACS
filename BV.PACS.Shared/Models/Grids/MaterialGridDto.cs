using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [GetDataUrl("api/Catalog/GetMaterials")]
    [GetCountUrl("api/Catalog/GetMaterialsRecordCount")]
    public class MaterialGridDto
    {
        [Column("idfMaterial")]
        public int MaterialId { get; set; }

        [Column("intNmbrOfContainers")]
        public string AliquotsCount { get; set; }

        [Column("strStrainNumber")]
        public string MaterialBarcode { get; set; }

        [Column("MaterialType")]
        public string MaterialType { get; set; }

        [Column("datRegistration_Date")]
        public DateTime MaterialRegistrationDate { get; set; }

        [Column("strNote")]
        public string MaterialNote { get; set; }

        [Column("strPointOfOrigin")]
        public string MaterialPointOfOrigin { get; set; }

        [Column("idfsCFormTemplateID")]
        public string MaterialTemplateId { get; set; }

        [Column("TemplateName")]
        public string MaterialTemplateName { get; set; }


        public override string ToString()
        {
            return $"Id:'{MaterialBarcode}', Registered:'{MaterialRegistrationDate}', Template:'{MaterialTemplateName}'";
        }
    }
}