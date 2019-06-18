using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [DataUrl("api/Catalog/GetMaterials")]
    [CountUrl("api/Catalog/GetMaterialsRecordCount")]
    public class MaterialListItem
    {
        [Column("idfMaterial")]
        public int MaterialId { get; set; }

        [Column("idfsMaterialTypeID")]
        public string MaterialTypeId { get; set; }

        [Column("datRegistration_Date")]
        public DateTime MaterialRegistrationDate { get; set; }

        [Column("AllowDelete")]
        public bool AllowDelete { get; set; }

        [Column("MaterialType")]
        public string MaterialType { get; set; }

        [Column("LogicalLockingStatus")]
        public string MaterialLockingStatusId { get; set; }

        [Column("strBarcode")]
        public string MaterialBarcode { get; set; }

        [Column("SourceName")]
        public string SourceName { get; set; }

        [Column("TemplateName")]
        public string MaterialTemplateName { get; set; }

        [Column("strNote")]
        public string MaterialNote { get; set; }

        [Column("idfsCFormTemplateID")]
        public string MaterialTemplateId { get; set; }

        [Column("intNmbrOfContainers")]
        public string AliquotsCount { get; set; }

        [Column("strSourceNumber")]
        public string SourceBarcode { get; set; }

        [Column("strOwnerName")]
        public string MaterialOwnerName { get; set; }

        [Column("strAliquotID")]
        public string Aliquots { get; set; }

        [Column("strPointOfOrigin")]
        public string MaterialPointOfOrigin { get; set; }


        public override string ToString()
        {
            return $"Id:'{MaterialBarcode}', Registered:'{MaterialRegistrationDate}', Template:'{MaterialTemplateName}'";
        }
    }
}