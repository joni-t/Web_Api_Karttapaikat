using System;
using System.Collections.Generic;

namespace Web_Api_Karttapaikat.Models
{
    public partial class Paikkamerkinta
    {
        public Paikkamerkinta()
        {
            KiertueEtappi = new HashSet<KiertueEtappi>();
        }

        public int PaikkaId { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int TyyppiId { get; set; }
        public string Kuvaus { get; set; }

        public PaikanTyyppi Tyyppi { get; set; }
        public ICollection<KiertueEtappi> KiertueEtappi { get; set; }
    }
}
