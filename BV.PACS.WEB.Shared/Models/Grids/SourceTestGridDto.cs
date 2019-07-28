namespace BV.PACS.WEB.Shared.Models
{
    // ReSharper disable once InconsistentNaming
    [StoredProcedures(GetProcedureName = "dbo.spSourceMaterialVial_SelectTests", KeyColumnName = "idfSource")]
    public class SourceTestGridDto: TestGridDto
    {
        
    }
}