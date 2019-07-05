namespace BV.PACS.Shared.Models
{
    [StoredProcedures(GetProcedureName = "dbo.spSourceMaterialVial_SelectTests", KeyColumnName = "idfVial")]
    public class AliquotTestGridDto : TestGridDto
    {
        
    }
}