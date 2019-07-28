using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using BV.PACS.WEB.Shared.Utils;

namespace BV.PACS.WEB.Shared.Models
{
    [Serializable]
    [XmlRoot("ConditionRoot")]
    public class AggregatedConditionDto
    {
        private static readonly Serializer<AggregatedConditionDto> Serializer = new Serializer<AggregatedConditionDto>();

        [XmlArray("ConditionList")]
        [XmlArrayItem("Condition")]
        public List<SearchConditionItemDto> ConditionItems { get; set; }

        [XmlArray("SortList")]
        [XmlArrayItem("Sort")]
        public List<SortConditionItemDto> SortItems { get; set; }

       
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = BaseSettings.PageSize;

        public string Language { get; set; } = BaseSettings.Language;
        public AggregatedConditionDto()
        {
            ConditionItems = new List<SearchConditionItemDto>();
            SortItems = new List<SortConditionItemDto>();
        }

        public AggregatedConditionDto(SearchConditionDto search, SortConditionDto sort) : this()
        {
            if (search != null)
            {
                ConditionItems.AddRange(search.Items);
            }

            if (sort != null)
            {
                SortItems.AddRange(sort.Items);
            }
        }

        public void AddStandardConditionIfNotEmpty(string fieldId, object value, string oper)
        {
            if (!value.IsNullOrEmpty())
            {
                ConditionItems.Add(new SearchConditionItemDto(fieldId, fieldId, value.Str(), oper, false));
            }
        }

        public string Serialize()
        {
            return Serializer.Serialize(this);
        }
    }
}