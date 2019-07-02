using System;

namespace BV.PACS.Shared.Models
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GetCountUrlAttribute :Attribute
    {
        public string Url { get; set; }
        public GetCountUrlAttribute(string url)
        {
            Url = url;
        }
    }
}