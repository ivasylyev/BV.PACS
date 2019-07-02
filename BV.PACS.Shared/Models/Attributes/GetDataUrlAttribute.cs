using System;

namespace BV.PACS.Shared.Models
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GetDataUrlAttribute :Attribute
    {
        public string Url { get; set; }

        public GetDataUrlAttribute(string url)
        {
            Url = url;
        }
    }
}