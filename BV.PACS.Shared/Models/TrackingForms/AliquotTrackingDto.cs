using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    [GetDataUrl("api/Tracking/GetAliquot")]
    [PostDataUrl("api/Tracking/PostAliquot")]
    public class AliquotTrackingDto
    {
        [GetColumn("idfContainer")]
        public int AliquotId { get; set; }

        [GetColumn("idfActivity")]
        public int ActivityId { get; set; }

        [GetColumn("strBarcode")]
        public string AliquotBarcode { get; set; }

        [GetColumn("datCreationDate")]
        public DateTime AliquotCreationDate { get; set; }

        [GetColumn("strNote")]
        public string AliquotNote { get; set; }

        [GetColumn("fltVolume")]
        public decimal Volume { get; set; }

        [GetColumn("fltWeight")]
        public decimal Weight { get; set; }

        [GetColumn("NullableVolume")]
        public decimal? NullableVolume { get; set; }

        [GetColumn("NullableWeight")]
        public decimal? NullableWeight { get; set; }

        [GetColumn("intGeneration")]
        public int Passage { get; set; }

        [GetColumn("StatusRef_Name")]
        public string AliquotStatus { get; set; }

        [GetColumn("idfsMaterialType")]
        public string MaterialTypeId { get; set; }

        [GetColumn("MaterialType")]
        public string MaterialType { get; set; }

        [GetColumn("strCultureShortName")]
        public string MaterialTypeShort { get; set; }

        [GetColumn("LocationPath")]
        public string LocationPath { get; set; }

        [GetColumn("idfMaterial")]
        public int MaterialId { get; set; }

        [GetColumn("idfSubdivisionID")]
        public int SubdivisionId { get; set; }

        [GetColumn("idfsContainer_Status")]
        public string AliquotStatusId { get; set; }

        [GetColumn("idfsStoring_Type")]
        public string StoringTypeId { get; set; }

        [GetColumn("idfsVolumeUnit")]
        public string VolumeUnitId { get; set; }

        [GetColumn("idfsWeightUnit")]
        public string WeightUnitId { get; set; }

        [GetColumn("idfsWeightUnit")]
        public string AliquotInitialBarcode { get; set; }

        [GetColumn("strInitialContainerID")]
        public string InitialContainerId { get; set; }

        [GetColumn("Material_strBarcode")]
        public string MaterialBarcode { get; set; }

        [GetColumn("VolumeUnitName")]
        public string VolumeUnitName { get; set; }

        [GetColumn("WeightUnitName")]
        public string WeightUnitName { get; set; }

        [GetColumn("Container_Detail_Status")]
        public string AliquotDetailStatus { get; set; }

        [GetColumn("blnTrackStockContainers")]
        public bool TrackStocAliquots { get; set; }

        [GetColumn("idfParentActivity")]
        public int ParentActivityId { get; set; }

        [GetColumn("idfsActivity_Type")]
        public string ActivityType { get; set; }

        [GetColumn("idfsDerivativeType")]
        public string DerivativeTypeId { get; set; }

        [GetColumn("DerivativeType")]
        public string DerivativeType { get; set; }

        [GetColumn("strDerivativeShortName")]
        public string DerivativeShortName { get; set; }

        [GetColumn("TemplateName")]
        public string AliquotTemplateName { get; set; }

        [GetColumn("idfsCFormTemplateID")]
        public string AliquotTemplateId { get; set; }

        [GetColumn("strParentBarcode")]
        public string AliquotParentBarcode { get; set; }

        [GetColumn("idfsUsageType")]
        public string UsageTypeId { get; set; }

        [GetColumn("UsageType_strDefault")]
        public string UsageType { get; set; }


        public override string ToString()
        {
            return $"Id:'{AliquotBarcode}', Created:'{AliquotCreationDate}', Template:'{AliquotTemplateName}'";
        }
    }
}