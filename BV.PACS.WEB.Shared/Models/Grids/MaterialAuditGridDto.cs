namespace BV.PACS.WEB.Shared.Models
{
    [StoredProcedures(GetProcedureName = "dbo.spDataAudit_Strain", KeyColumnName = "ID")]
    public class MaterialAuditGridDto : AuditGridDto
    {
    }
}