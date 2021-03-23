using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoIG.Models.ModelRequest
{
    public class CustomerRequest
    {
        public int customerId { get; set; }
        public int personID { get; set; }
        public int storeId { get; set; }
        public int territoryId { get; set; }
    }
}
