namespace BV.PACS.Shared.Models
{
    [StoredProcedures(GetProcedureName = "dbo.spDataAudit_Container", KeyColumnName = "ID")]
    public class AliquotAuditGridDto: AuditGridDto
    {
        
    }
}