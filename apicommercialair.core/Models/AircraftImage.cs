using System;
using System.Collections.Generic;
using System.Text;

namespace apicommercialair.core.Models
{
    public class AircraftImage
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public DateTime TimeStamp { get; set; }

        public int VariantId { get; set; }
        public Variant Variant { get; set; }
    }
}
