using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapiInsurer.Models;

namespace webapiInsurer
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {

        Repositories.IDataAccess<Update_Contract_PUT_Method_API, string> _procrepo;
        public UpdateController(Repositories.IDataAccess<Update_Contract_PUT_Method_API, string> b)
        {
            _procrepo = b;
        }
        // POST api/values : https://localhost:44358/api/contract (Insert values in the body content type: /application/json)
        [HttpPost]
     

       

        [HttpPut("{CustomerName}")]
        [Route("Updatecontractwithproccall")]
        public IActionResult Put([FromBody] Update_Contract_PUT_Method_API b, string CustomerName)
        {
            
                int res = _procrepo.Updatecontractwithproccall(b, CustomerName);
                if (res != 0)
                {
                    return Ok(res);
                }
                return NotFound();
            
        }

    }
}
