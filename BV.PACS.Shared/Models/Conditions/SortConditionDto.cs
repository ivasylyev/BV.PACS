using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using BV.PACS.Shared.Utils;

namespace BV.PACS.Shared.Models
{
    [Serializable]
    [XmlRoot("SortRoot")]
    public class SortConditionDto
    {
        private static readonly Serializer<SortConditionDto> Serializer = new Serializer<SortConditionDto>();

        public static SortConditionDto GetEmpty => new SortConditionDto();

        [XmlArray("SortList")]
        [XmlArrayItem("Sort")]
        public List<SortConditionItemDto> Items { get; set; }

        public SortConditionDto()
        {
            Items = new List<SortConditionItemDto>();
        }

        public SortConditionDto(string fieldId, string objectId, OrderDirection direction = OrderDirection.ASC) : this()
        {
            AddStandardIfNotEmpty(fieldId, objectId, direction);
        }

        public string Serialize()
        {
            return Serializer.Serialize(this);
        }

        public void AddStandardIfNotEmpty(string fieldId, string objectId, OrderDirection direction = OrderDirection.ASC)
        {
            if (!fieldId.IsNullOrEmpty())
            {
                var itemsCount = Items.Count;
                Items.Add(new SortConditionItemDto(fieldId, objectId, direction) {SortingOrder = itemsCount});
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in Items)
            {
                sb.AppendFormat("{0} ", item);
            }

            var itemString = sb.ToString();
            return itemString.TrimEnd(' ');
        }
    }
}