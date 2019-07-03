using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    // ReSharper disable once InconsistentNaming
    public class StoredProceduresAttribute : Attribute
    {
       public string GetProcedureName { get; set; }
       public string PostProcedureName { get; set; }
       public string KeyColumnName { get; set; }

       public StoredProceduresAttribute()
       {
       }

       public StoredProceduresAttribute(string getProcedureName, string postProcedureName, string keyColumnName)
       {
           GetProcedureName = getProcedureName;
           PostProcedureName = postProcedureName;
           KeyColumnName = keyColumnName;
       }
    }
}