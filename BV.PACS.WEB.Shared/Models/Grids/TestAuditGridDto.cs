namespace BV.PACS.WEB.Shared.Models
{
    [StoredProcedures(GetProcedureName = "dbo.spDataAudit_Test", KeyColumnName = "ID")]
    public class TestAuditGridDto: AuditGridDto
    {
        
    }
}