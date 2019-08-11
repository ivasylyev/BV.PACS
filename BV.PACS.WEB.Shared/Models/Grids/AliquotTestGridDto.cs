namespace BV.PACS.WEB.Shared.Models
{
    [StoredProcedures(GetProcedureName = "dbo.spSourceMaterialVial_SelectTests", KeyColumnName = "idfVial")]
    public class AliquotTestGridDto : TestGridDto
    {
    }
}