using System;
using System.Collections.Generic;

namespace Web_Api_Karttapaikat.Models
{
    public partial class KiertueEtappi
    {
        public int EtappiId { get; set; }
        public int PaikkaId { get; set; }
        public int KiertueId { get; set; }

        public Kiertue Kiertue { get; set; }
        public Paikkamerkinta Paikka { get; set; }
    }
}
