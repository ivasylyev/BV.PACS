using System;
using System.Xml.Serialization;

namespace BV.PACS.WEB.Shared.Models
{
    [Serializable]
    [XmlRoot("Sort")]
    public class SortConditionItemDto
    {
        public string FieldId { get; set; }

        public string ObjectId { get; set; }

        public OrderDirection SortDirection { get; set; }

        public int SortingOrder { get; set; }

        public SortConditionItemDto()
        {
        }

        public SortConditionItemDto(string fieldId, string objectId, OrderDirection direction = OrderDirection.ASC)
        {
            FieldId = fieldId;
            ObjectId = objectId;
            SortDirection = direction;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(FieldId))
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(ObjectId))
            {
                return $"{FieldId} {SortDirection.ToString()}";
            }

            return $"{ObjectId}.{FieldId} {SortDirection.ToString()}";
        }
    }
}