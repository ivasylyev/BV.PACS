using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace BV.PACS.WEB.Shared.Models
{
    [Serializable]
    [XmlRoot("Condition")]
    public class SearchConditionItemDto
    {
        private readonly List<string> _columnNamesList = new List<string>
        {
            "strBarcode", "strContainerBarcode", "strContainerNumber",
            "strMaterialBarcode", "Material_strBarcode", "strSourceBarcode"
        };

        public string FieldId { get; set; }

        public string FieldName { get; set; }

        public string FieldValue { get; set; }

        public string Operator { get; set; }

        public bool IsCustom { get; set; }

        public SearchConditionItemDto()
        {
        }

        public SearchConditionItemDto(string fieldId, string fieldName, string fieldValue, string @operator, bool isCustom)
        {
            if (_columnNamesList.Any(fieldId.Contains)
                && string.Equals(@operator, "Like", StringComparison.InvariantCulture))
            {
                FieldValue = fieldValue.Replace("_", "[_]").Replace("*", "_");
            }
            else
            {
                FieldValue = fieldValue;
            }

            FieldId = fieldId;
            FieldName = fieldName;
            Operator = @operator;
            IsCustom = isCustom;
        }
    }
}