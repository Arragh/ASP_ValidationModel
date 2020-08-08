using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_ValidationModel.ViewModels
{
    public class AddSectionViewModel
    {
        [Required]
        public string SectionTitle { get; set; }
    }
}
