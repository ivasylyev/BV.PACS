using System;

namespace BV.PACS.Shared.Models
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CountUrlAttribute :Attribute
    {
        public string Url { get; set; }
        public CountUrlAttribute(string url)
        {
            Url = url;
        }
    }
}