using System;
using System.Collections.Generic;
using System.Text;

namespace apicommercialair.core.Models
{
    public enum AircraftCategory
    {
        Widebody, Narrowbody
    }

    public class Aircraft
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AircraftCategory? AircraftCategory { get; set; }

        public DateTime? FirstFlight { get; set; }

        public DateTime? Introduction { get; set; }

        //  EF Core interprets a property as a foreign key if it's named <navigation
        //  property name><primary key property name>.
        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public ICollection<Variant> Variants { get; set; }
    }
}
