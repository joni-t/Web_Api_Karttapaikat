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
    public class KiertueController : ControllerBase
    {
        PaikkaDbContext context = new PaikkaDbContext();

        //yhden kiertueen palauttaminen
        [HttpGet]
        [Route("{id}")]  
        public Kiertue GetSingle(int id)
        {
            try
            {
                Kiertue kiertue = context.Kiertue.Find(id);
                return kiertue;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //kiertueen lisääminen
        [HttpPost]
        [Route("")]
        public int PostCreateNew(int KiertueId, [FromBody] Kiertue kiertue)
        {
            try
            {
                context.Add(kiertue);
                context.SaveChanges();

                return kiertue.KiertueId;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}