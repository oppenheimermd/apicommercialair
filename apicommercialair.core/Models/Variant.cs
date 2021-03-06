using System;
using System.Collections.Generic;
using System.Text;

namespace apicommercialair.core.Models
{
    public class Variant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //  EF Core interprets a property as a foreign key if it's named <navigation
        //  property name><primary key property name>.
        public int AircraftId { get; set; }

        public Aircraft Aircraft { get; set; }

        public ICollection<AircraftImage> AircraftImages { get; set; }
    }
}
