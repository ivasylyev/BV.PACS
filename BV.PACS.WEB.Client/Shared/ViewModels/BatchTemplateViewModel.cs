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
        [Range(1,BaseSettings.MaxBatchRegistrationSize)]
        public int SourceCount { get; set; }

        [Required]
        [Range(1, BaseSettings.MaxBatchRegistrationSize)]
        public int MaterialCount { get; set; }

        [Required]
        [Range(1, BaseSettings.MaxBatchRegistrationSize)]
        public int AliquotCount { get; set; }
    }
}