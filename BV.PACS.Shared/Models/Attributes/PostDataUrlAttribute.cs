using System;

namespace BV.PACS.Shared.Models
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PostDataUrlAttribute : Attribute
    {
        public string Url { get; set; }

        public PostDataUrlAttribute(string url)
        {
            Url = url;
        }
    }
}