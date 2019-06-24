using System;

namespace BV.PACS.Shared.Models
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DataUrlAttribute :Attribute
    {
        public string Url { get; set; }

        public DataUrlAttribute(string url)
        {
            Url = url;
        }
    }
}