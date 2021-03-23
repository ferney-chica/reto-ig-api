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
    public class SalesDetailsController : ControllerBase
    {

        [HttpGet]
        public ActionResult Get()
        {
            using (Models.AdventureWorks2019Context db = new Models.AdventureWorks2019Context())
            {
                var sales = (from sales19 in db.SalesOrderDetails
                             select sales19).ToList();
                return Ok(sales);
            }
            //return new String[] { "Ferney", "Yuliana", "Maria Alejandra" };
        }
    }
}
