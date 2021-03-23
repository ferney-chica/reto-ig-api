

using Microsoft.AspNetCore.Cors;
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
    
    public class CustomersController : ControllerBase
    {
        
        [HttpGet] //Obtención de datos
        

        public ActionResult Get() 
        {
            using (Models.AdventureWorks2019Context db = new Models.AdventureWorks2019Context())
            {
                var customers = (from customers19 in db.Customers
                                   select customers19).ToList();
                return Ok(customers);
            }
            //return new String[] { "Ferney", "Yuliana", "Maria Alejandra" };
        }


        // GET api/<ValuesController>/5 Obtenci{on de un solo customer por id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            using (Models.AdventureWorks2019Context db = new Models.AdventureWorks2019Context())
            {
                var customer = (from customers19 in db.Customers
                                where customers19.CustomerId==id
                                select customers19).ToList();
                return Ok(customer);
            }
        }


        [HttpPost] //Inserción de datos
        public ActionResult Post([FromBody] Models.ModelRequest.CustomerRequest model)
        {
            using (Models.AdventureWorks2019Context db = new Models.AdventureWorks2019Context())
            {
                Models.Customer customer = new Models.Customer();
                customer.PersonId = model.personID;
                customer.StoreId = model.storeId;
                customer.TerritoryId = model.territoryId;
                db.Customers.Add(customer);
                db.SaveChanges();

            }
            return Ok();
        }

        [HttpPut] //Edicion de datos
        public ActionResult Put([FromBody] Models.ModelRequest.CustomerRequest model)
        {
            using (Models.AdventureWorks2019Context db = new Models.AdventureWorks2019Context())
            {
                Models.Customer customer = db.Customers.Find(model.customerId);
                customer.PersonId = model.personID;
                customer.StoreId = model.storeId;
                customer.TerritoryId = model.territoryId;
                db.Entry(customer).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }
            return Ok();
        }
    }
}
