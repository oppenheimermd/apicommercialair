using System;
using System.Collections.Generic;
using System.Text;

namespace apicommercialair.core.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public string CompanyWebsite { get; set; }

        public ICollection<Aircraft> Aircraft { get; set; }
    }
}
