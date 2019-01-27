using System;
using System.Collections.Generic;

namespace Web_Api_Karttapaikat.Models
{
    public partial class PaikanTyyppi
    {
        public PaikanTyyppi()
        {
            Paikkamerkinta = new HashSet<Paikkamerkinta>();
        }

        public int TyyppiId { get; set; }
        public string Tyyppi { get; set; }

        public ICollection<Paikkamerkinta> Paikkamerkinta { get; set; }
    }
}
