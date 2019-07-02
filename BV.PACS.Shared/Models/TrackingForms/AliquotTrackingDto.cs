using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [GetDataUrl("api/Tracking/GetAliquot")]
    [PostDataUrl("api/Tracking/PostAliquot")]
    public class AliquotTrackingDto
    {
        [Column("idfContainer")]
        public int AliquotId { get; set; }

        [Column("idfActivity")]
        public int ActivityId { get; set; }

        [Column("strBarcode")]
        public string AliquotBarcode { get; set; }

        [Column("datCreationDate")]
        public DateTime AliquotCreationDate { get; set; }

        [Column("strNote")]
        public string AliquotNote { get; set; }

        [Column("fltVolume")]
        public decimal Volume { get; set; }

        [Column("fltWeight")]
        public decimal Weight { get; set; }

        [Column("NullableVolume")]
        public decimal? NullableVolume { get; set; }

        [Column("NullableWeight")]
        public decimal? NullableWeight { get; set; }

        [Column("intGeneration")]
        public int Passage { get; set; }

        [Column("StatusRef_Name")]
        public string AliquotStatus { get; set; }

        [Column("idfsMaterialType")]
        public string MaterialTypeId { get; set; }

        [Column("MaterialType")]
        public string MaterialType { get; set; }

        [Column("strCultureShortName")]
        public string MaterialTypeShort { get; set; }

        [Column("LocationPath")]
        public string LocationPath { get; set; }

        [Column("idfMaterial")]
        public int MaterialId { get; set; }

        [Column("idfSubdivisionID")]
        public int SubdivisionId { get; set; }

        [Column("idfsContainer_Status")]
        public string AliquotStatusId { get; set; }

        [Column("idfsStoring_Type")]
        public string StoringTypeId { get; set; }

        [Column("idfsVolumeUnit")]
        public string VolumeUnitId { get; set; }

        [Column("idfsWeightUnit")]
        public string WeightUnitId { get; set; }

        [Column("idfsWeightUnit")]
        public string AliquotInitialBarcode { get; set; }

        [Column("strInitialContainerID")]
        public string InitialContainerId { get; set; }

        [Column("Material_strBarcode")]
        public string MaterialBarcode { get; set; }

        [Column("VolumeUnitName")]
        public string VolumeUnitName { get; set; }

        [Column("WeightUnitName")]
        public string WeightUnitName { get; set; }

        [Column("Container_Detail_Status")]
        public string AliquotDetailStatus { get; set; }

        [Column("blnTrackStockContainers")]
        public bool TrackStocAliquots { get; set; }

        [Column("idfParentActivity")]
        public int ParentActivityId { get; set; }

        [Column("idfsActivity_Type")]
        public string ActivityType { get; set; }

        [Column("idfsDerivativeType")]
        public string DerivativeTypeId { get; set; }

        [Column("DerivativeType")]
        public string DerivativeType { get; set; }

        [Column("strDerivativeShortName")]
        public string DerivativeShortName { get; set; }

        [Column("TemplateName")]
        public string AliquotTemplateName { get; set; }

        [Column("idfsCFormTemplateID")]
        public string AliquotTemplateId { get; set; }

        [Column("strParentBarcode")]
        public string AliquotParentBarcode { get; set; }

        [Column("idfsUsageType")]
        public string UsageTypeId { get; set; }

        [Column("UsageType_strDefault")]
        public string UsageType { get; set; }


        public override string ToString()
        {
            return $"Id:'{AliquotBarcode}', Created:'{AliquotCreationDate}', Template:'{AliquotTemplateName}'";
        }
    }
}