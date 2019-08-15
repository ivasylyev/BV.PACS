using System.ComponentModel.DataAnnotations;
using BV.PACS.WEB.Shared.Models;

namespace BV.PACS.WEB.Client.Shared.ViewModels
{
    public class BatchTemplateViewModel
    {
        [Required]
        public TemplateLookupItem SourceTemplate { get; set; }

        [Required]
        public TemplateLookupItem MaterialTemplate { get; set; }

        [Required]
        public TemplateLookupItem AliquotTemplate { get; set; }

        [Required]
        public int SourceCount { get; set; }

        [Required]
        public int MaterialCount { get; set; }

        [Required]
        public int AliquotCount { get; set; }
    }
}