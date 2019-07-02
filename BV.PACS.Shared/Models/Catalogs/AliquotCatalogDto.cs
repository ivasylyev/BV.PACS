using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [GetDataUrl("api/Catalog/GetAliquots")]
    [GetCountUrl("api/Catalog/GetAliquotsRecordCount")]
    public class AliquotCatalogDto
    {
        [Column("idfContainer")]
        public int AliquotId { get; set; }

        [Column("strBarcode")]
        public string AliquotBarcode { get; set; }

        [Column("datCreationDate")]
        public DateTime AliquotCreationDate { get; set; }

        [Column("Material_strBarcode")]
        public string MaterialBarcode { get; set; }

        [Column("FreezerSubdivision_strBarcode")]
        public string FreezerSubdivisionBarcode { get; set; }

        [Column("idfsContainer_Status")]
        public string AliquotStatusId { get; set; }

        [Column("StatusRef_Name")]
        public string AliquotStatus { get; set; }

        [Column("intGeneration")]
        public int Generation { get; set; }

        [Column("idfMaterial")]
        public string MaterialId { get; set; }

        [Column("MaterialType")]
        public string MaterialType { get; set; }

        [Column("LogicalLockingStatus")]
        public string AliquotLockingStatusId { get; set; }

        [Column("strVolume")]
        public string VolumeString { get; set; }

        [Column("strWeight")]
        public string WeightString { get; set; }

        [Column("strNote")]
        public string AliquotNote { get; set; }

        [Column("strRFIDCode")]
        public string RFIDCode { get; set; }

        [Column("strSpotPosition")]
        public string SpotPosition { get; set; }

        [Column("DerivativeType")]
        public string DerivativeType { get; set; }

        [Column("strSourceNumber")]
        public string SourceBarcode { get; set; }

        [Column("TemplateName")]
        public string AliquotTemplateName { get; set; }

        [Column("LocationPath")]
        public string LocationPath { get; set; }

        [Column("idfsCFormTemplateID")]
        public string AliquotTemplateId { get; set; }

        [Column("idfsVolumeUnit")]
        public string VolumeUnitId { get; set; }

        [Column("idfsWeightUnit")]
        public string WeightUnitId { get; set; }

        [Column("fltVolume")]
        public float Volume { get; set; }

        [Column("fltWeight")]
        public float Weight { get; set; }


        public override string ToString()
        {
            return $"Id:'{AliquotBarcode}', Created:'{AliquotCreationDate}', Template:'{AliquotTemplateName}'";
        }
    }
}