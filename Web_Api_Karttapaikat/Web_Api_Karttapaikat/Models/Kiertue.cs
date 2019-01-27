using System;
using System.Collections.Generic;

namespace Web_Api_Karttapaikat.Models
{
    public partial class Kiertue
    {
        public Kiertue()
        {
            KiertueEtappi = new HashSet<KiertueEtappi>();
        }

        public int KiertueId { get; set; }
        public int SiirtymistapaId { get; set; }
        public string Kuvaus { get; set; }

        public Siirtymistapa Siirtymistapa { get; set; }
        public ICollection<KiertueEtappi> KiertueEtappi { get; set; }
    }
}
