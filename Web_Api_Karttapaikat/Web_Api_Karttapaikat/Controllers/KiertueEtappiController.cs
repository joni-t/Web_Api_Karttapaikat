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
    public class KiertueEtappiController : ControllerBase
    {
        PaikkaDbContext context = new PaikkaDbContext();

        //kiertue etappien palauttaminen
        [HttpGet]
        [Route("")]
        public List<KiertueEtappi> GetAll()
        {
            List<KiertueEtappi> etapit = context.KiertueEtappi.ToList();

            return etapit;
        }

        //uuden kiertue etapin lisääminen
        [HttpPost]
        [Route("")]
        public int PostCreateNew(int EtappiId, [FromBody] KiertueEtappi etappi)
        {
            try
            {
                context.Add(etappi);
                context.SaveChanges();

                return etappi.EtappiId;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}