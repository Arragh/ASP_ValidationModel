using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_ValidationModel.ViewModels
{
    public class AddSubsectionViewModel
    {
        [Required]
        public string SubsectionTitle { get; set; }
        [Required]
        public string SectionId { get; set; }
    }
}
