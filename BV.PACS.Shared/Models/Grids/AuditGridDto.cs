namespace BV.PACS.Shared.Models
{
    public abstract class AuditGridDto
    {
        [GetColumn("ID")]
        public int Id { get; set; }

        [GetColumn("idfsMainObject")]
        public string MainObjectId { get; set; }

       
        // VeryMainObjectID
        // DataAuditEventType
        // strGroupping
        // datEnteringDate
        // ActorName
        // idfsDataAuditEventType
        // strReason
        // strColumn
        // ColumnName
        // idfsObject
        // strObjectTable
        // intAction
        // strOldValue
        // strNewValue
        // strObjectKey
        // strObject
        // idfsCFParameterTypeID
    }
}