using System;

namespace BV.PACS.Shared.Models
{
    [StoredProcedures(GetProcedureName = "dbo.spSource_Diagnostics", KeyColumnName = "idfSource")]
    // ReSharper disable once InconsistentNaming
    public class SourceDiagnosticsDto
    {
        [GetColumn("idfActivity")]
        public int ActivityId { get; set; }

        [GetColumn("strActivityCode")]
        public string ActivityCode { get; set; }

        [GetColumn("datStartDate")]
        public DateTime? StartDate { get; set; }

        [GetColumn("datValidateDate")]
        public DateTime? ValidateDate { get; set; }

        [GetColumn("datModificationDate")]
        public DateTime? ChangedDate { get; set; }

        [GetColumn("strStatus")]
        public string Status { get; set; }

        [GetColumn("strNote")]
        public string Note { get; set; }

        [GetColumn("idfsActivity_Status")]
        public string ActivityStatusId { get; set; }

        [GetColumn("idfPerformedBy")]
        public int PerformedById { get; set; }

        [GetColumn("idfValidatedBy")]
        public int ValidatedById { get; set; }

        [GetColumn("strTestSets")]
        public string TestSet { get; set; }

        [GetColumn("strPerformedByName")]
        public string PerformedByName { get; set; }

        [GetColumn("strValidatedByName")]
        public string ValidatedByName { get; set; }

        [GetColumn("strMaterialNumber")]
        public string MaterialBarcode { get; set; }
    }
}