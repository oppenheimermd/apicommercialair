using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace apicommercialair.core.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        [StringLength(256)]
        [Display(Name = "Website")]
        public string CompanyWebsite { get; set; }

        [StringLength(800)]
        [Display(Name = "About")]
        public string CompanyAbout { get; set; }

        public ICollection<Aircraft> Aircraft { get; set; }
    }
}
