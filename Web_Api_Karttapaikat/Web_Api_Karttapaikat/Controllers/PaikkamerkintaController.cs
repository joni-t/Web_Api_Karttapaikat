using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Karttapaikat.Models;

namespace Web_Api_Karttapaikat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaikkamerkintaController : ControllerBase
    {
        PaikkaDbContext context = new PaikkaDbContext();

        //kohteiden palauttaminen
        [HttpGet]
        [Route("")]
        public List<Paikkamerkinta> GetAll()
        {
            List<Paikkamerkinta> paikat = context.Paikkamerkinta.ToList();

            return paikat;
        }

        //yhden kohteen palauttaminen
        [HttpGet]
        [Route("{id}")]  
        public Paikkamerkinta GetSingle(int id) 
        {
            Paikkamerkinta paikka = context.Paikkamerkinta.Find(id);
            return paikka;
        }

        //kohteiden palauttaminen, jotka ovat tiettyä tyyppiä
        [HttpPost]
        [Route("getselected/type")]
        public List<Paikkamerkinta> PostGetByType(int paikkaId, [FromBody] List<int> ids)
        {
            List<Paikkamerkinta> paikat = GetAll();
            List<Paikkamerkinta> paikat_suodatettu = new List<Paikkamerkinta>();
            foreach (int tyyppi_id in ids)
            {
                foreach(Paikkamerkinta paikka in paikat)
                {
                    if (tyyppi_id == paikka.TyyppiId)
                    {
                        paikka.Tyyppi = context.PaikanTyyppi.Find(paikka.TyyppiId);
                        paikka.Tyyppi.Paikkamerkinta = null;
                        paikat_suodatettu.Add(paikka);
                    }
                }
            }
            return paikat_suodatettu;
        }

        //tietyn kiertueen kohteiden palauttaminen
        [HttpPost]
        [Route("getselected/route")]
        public List<Paikkamerkinta> PostGetByRoute(int paikkaId, [FromBody] int KiertueId)
        {
            List<Paikkamerkinta> paikat = GetAll();
            List<Paikkamerkinta> paikat_suodatettu = new List<Paikkamerkinta>();
            List<KiertueEtappi> kiertue_etapit = context.KiertueEtappi.ToList();



            foreach (KiertueEtappi etappi in kiertue_etapit)
            {
                if (etappi.KiertueId == KiertueId)
                {
                    foreach (Paikkamerkinta paikka in paikat)
                    {
                        if (etappi.PaikkaId == paikka.PaikkaId)
                        {
                            paikka.Tyyppi = context.PaikanTyyppi.Find(paikka.TyyppiId);
                            paikka.Tyyppi.Paikkamerkinta = null;
                            paikka.KiertueEtappi = null;
                            paikat_suodatettu.Add(paikka);
                        }
                    }
                }
            }
            return paikat_suodatettu;
        }

        //kohteen lisääminen
        [HttpPost]
        [Route("")]
        public int PostCreateNew(int paikkaId, [FromBody] Paikkamerkinta paikka)
        {
            try
            {
                context.Add(paikka);
                context.SaveChanges();

                return paikka.PaikkaId;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}