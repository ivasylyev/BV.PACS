using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [GetDataUrl("api/Catalog/GetMaterials")]
    [GetCountUrl("api/Catalog/GetMaterialsRecordCount")]
    public class MaterialGridDto
    {
        [GetColumn("idfMaterial")]
        public int MaterialId { get; set; }

        [GetColumn("intNmbrOfContainers")]
        public string AliquotsCount { get; set; }

        [GetColumn("strStrainNumber")]
        public string MaterialBarcode { get; set; }

        [GetColumn("MaterialType")]
        public string MaterialType { get; set; }

        [GetColumn("datRegistration_Date")]
        public DateTime MaterialRegistrationDate { get; set; }

        [GetColumn("strNote")]
        public string MaterialNote { get; set; }

        [GetColumn("strPointOfOrigin")]
        public string MaterialPointOfOrigin { get; set; }

        [GetColumn("idfsCFormTemplateID")]
        public string MaterialTemplateId { get; set; }

        [GetColumn("TemplateName")]
        public string MaterialTemplateName { get; set; }


        public override string ToString()
        {
            return $"Id:'{MaterialBarcode}', Registered:'{MaterialRegistrationDate}', Template:'{MaterialTemplateName}'";
        }
    }
}