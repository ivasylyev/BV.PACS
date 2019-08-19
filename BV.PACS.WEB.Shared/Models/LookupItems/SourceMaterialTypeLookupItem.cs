namespace BV.PACS.WEB.Shared.Models
{
    public class SourceMaterialTypeLookupItem
    {
        [GetColumn("idfsReference")]
        public string Id { get; set; }

        [GetColumn("idfsParentBaseReference")]
        public string ParentId { get; set; }

        [GetColumn("InUseCount")]
        public int InUseCount { get; set; }

        [GetColumn("Level")]
        public int Level { get; set; }

        [GetColumn("NAME")]
        public string Name { get; set; }


        [GetColumn("LongName")]
        public string LongName { get; set; }


        [GetColumn("strShortName")]
        public string ShortName { get; set; }

        [GetColumn("idfsReference_Type")]
        public string ReferenceType { get; set; }


        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}