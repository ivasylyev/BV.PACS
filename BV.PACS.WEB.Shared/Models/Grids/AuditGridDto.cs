using System;

namespace BV.PACS.WEB.Shared.Models
{
    public abstract class AuditGridDto
    {

        public string GroupHeader => $"{EnteringDate} {DataAuditEventType} {ActorName}";


        [GetColumn("ID")]
        public int Id { get; set; }

        [GetColumn("idfsMainObject")]
        public string MainObjectId { get; set; }

        [GetColumn("VeryMainObjectID")]
        public string VeryMainObjectId { get; set; }

        [GetColumn("DataAuditEventType")]
        public string DataAuditEventType { get; set; }

        [GetColumn("strGroupping")]
        public string Grouping { get; set; }

        [GetColumn("datEnteringDate")]
        public DateTime EnteringDate { get; set; }

        [GetColumn("ActorName")]
        public string ActorName { get; set; }

        [GetColumn("idfsDataAuditEventType")]
        public string DataAuditEventTypeId { get; set; }

        [GetColumn("strReason")]
        public string Reason { get; set; }

        [GetColumn("strColumn")]
        public string ColumnId { get; set; }

        [GetColumn("ColumnName")]
        public string ColumnName { get; set; }

        [GetColumn("idfsObject")]
        public string ObjectId { get; set; }

        [GetColumn("strObjectTable")]
        public string ObjectTable { get; set; }

        [GetColumn("intAction")]
        public int Action { get; set; }

        [GetColumn("strOldValue")]
        public string OldValue { get; set; }

        [GetColumn("strNewValue")]
        public string NewValue { get; set; }

        [GetColumn("strObjectKey")]
        public string ObjectKey { get; set; }

        [GetColumn("strObject")]
        public string Object { get; set; }

        [GetColumn("idfsCFParameterTypeID")]
        public string CustomParameterTypeId { get; set; }
    }
}