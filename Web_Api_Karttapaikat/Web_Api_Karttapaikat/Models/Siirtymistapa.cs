using System;
using System.Collections.Generic;

namespace Web_Api_Karttapaikat.Models
{
    public partial class Siirtymistapa
    {
        public Siirtymistapa()
        {
            Kiertue = new HashSet<Kiertue>();
        }

        public int TapaId { get; set; }
        public string Selite { get; set; }

        public ICollection<Kiertue> Kiertue { get; set; }
    }
}
