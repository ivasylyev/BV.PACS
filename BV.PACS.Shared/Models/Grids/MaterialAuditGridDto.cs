namespace BV.PACS.Shared.Models
{
    [StoredProcedures(GetProcedureName = "dbo.spDataAudit_Strain", KeyColumnName = "ID")]
    public class MaterialAuditGridDto: AuditGridDto
    {
        
    }
}