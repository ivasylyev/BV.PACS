namespace BV.PACS.WEB.Shared.Models
{
    // ReSharper disable once InconsistentNaming
    [StoredProcedures(GetProcedureName = "dbo.spDataAudit_Source", KeyColumnName = "ID")]
    public class SourceAuditGridDto : AuditGridDto
    {
    }
}