using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.WEB.Shared.Models
{
    public class MaterialCatalogDto
    {
        [GetColumn("idfMaterial")]
        public int MaterialId { get; set; }

        [GetColumn("idfsMaterialTypeID")]
        public string MaterialTypeId { get; set; }

        [GetColumn("datRegistration_Date")]
        public DateTime MaterialRegistrationDate { get; set; }

        [GetColumn("AllowDelete")]
        public bool AllowDelete { get; set; }

        [GetColumn("MaterialType")]
        public string MaterialType { get; set; }

        [GetColumn("LogicalLockingStatus")]
        public string MaterialLockingStatusId { get; set; }

        [GetColumn("strBarcode")]
        public string MaterialBarcode { get; set; }

        [GetColumn("SourceName")]
        public string SourceName { get; set; }

        [GetColumn("TemplateName")]
        public string MaterialTemplateName { get; set; }

        [GetColumn("strNote")]
        public string MaterialNote { get; set; }

        [GetColumn("idfsCFormTemplateID")]
        public string MaterialTemplateId { get; set; }

        [GetColumn("intNmbrOfContainers")]
        public string AliquotsCount { get; set; }

        [GetColumn("strSourceNumber")]
        public string SourceBarcode { get; set; }

        [GetColumn("strOwnerName")]
        public string MaterialOwnerName { get; set; }

        [GetColumn("strAliquotID")]
        public string Aliquots { get; set; }

        [GetColumn("strPointOfOrigin")]
        public string MaterialPointOfOrigin { get; set; }


        public override string ToString()
        {
            return $"Id:'{MaterialBarcode}', Registered:'{MaterialRegistrationDate}', Template:'{MaterialTemplateName}'";
        }
    }
}