using System;

namespace BV.PACS.Shared.Models
{
    [StoredProcedures(GetProcedureName = "dbo.spMaterial_SelectVials", KeyColumnName = "idfMaterial")]
    public class MaterialAliquotGridDto
    {
//        
//        [GetColumn("idfContainer")]
//        public int AliquotId { get; set; }
//
//        [GetColumn("strBarcode")]
//        public string AliquotBarcode { get; set; }
//
//        [GetColumn("datCreationDate")]
//        public DateTime AliquotCreationDate { get; set; }
//
//        [GetColumn("Material_strBarcode")]
//        public string MaterialBarcode { get; set; }
//
//        [GetColumn("FreezerSubdivision_strBarcode")]
//        public string FreezerSubdivisionBarcode { get; set; }
//
//        [GetColumn("idfsContainer_Status")]
//        public string AliquotStatusId { get; set; }
//
//        [GetColumn("StatusRef_Name")]
//        public string AliquotStatus { get; set; }
//
//        [GetColumn("intGeneration")]
//        public int Generation { get; set; }
//
//        [GetColumn("idfMaterial")]
//        public string MaterialId { get; set; }
//
//        [GetColumn("MaterialType")]
//        public string MaterialType { get; set; }
//
//        [GetColumn("LogicalLockingStatus")]
//        public string AliquotLockingStatusId { get; set; }
//
//        [GetColumn("strVolume")]
//        public string VolumeString { get; set; }
//
//        [GetColumn("strWeight")]
//        public string WeightString { get; set; }
//
//        [GetColumn("strNote")]
//        public string AliquotNote { get; set; }
//
//        [GetColumn("strRFIDCode")]
//        public string RFIDCode { get; set; }
//
//        [GetColumn("strSpotPosition")]
//        public string SpotPosition { get; set; }
//
//        [GetColumn("DerivativeType")]
//        public string DerivativeType { get; set; }
//
//        [GetColumn("strSourceNumber")]
//        public string SourceBarcode { get; set; }
//
//        [GetColumn("TemplateName")]
//        public string AliquotTemplateName { get; set; }
//
//        [GetColumn("LocationPath")]
//        public string LocationPath { get; set; }
//
//        [GetColumn("idfsCFormTemplateID")]
//        public string AliquotTemplateId { get; set; }
//
//        [GetColumn("idfsVolumeUnit")]
//        public string VolumeUnitId { get; set; }
//
//        [GetColumn("idfsWeightUnit")]
//        public string WeightUnitId { get; set; }
//
//        [GetColumn("fltVolume")]
//        public float Volume { get; set; }
//
//        [GetColumn("fltWeight")]
//        public float Weight { get; set; }
//
//
//        public override string ToString()
//        {
//            return $"Id:'{AliquotBarcode}', Created:'{AliquotCreationDate}', Template:'{AliquotTemplateName}'";
//        }
    }
}