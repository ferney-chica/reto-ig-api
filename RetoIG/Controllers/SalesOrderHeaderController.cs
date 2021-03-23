using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoIG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderHeaderController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.AdventureWorks2019Context db = new Models.AdventureWorks2019Context())
            {
                var salesHeader = (from salesHeader19 in db.SalesOrderHeaders
                             select salesHeader19).ToList();
                return Ok(salesHeader);
            }
            //return new String[] { "Ferney", "Yuliana", "Maria Alejandra" };
        }
    }
}
