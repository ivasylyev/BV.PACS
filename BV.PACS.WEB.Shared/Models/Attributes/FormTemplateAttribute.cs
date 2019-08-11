using System;

namespace BV.PACS.WEB.Shared.Models
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FormTemplateAttribute : Attribute
    {
        public string FormType { get; set; }

        public FormTemplateAttribute(string formType)
        {
            FormType = formType;
        }
    }
}