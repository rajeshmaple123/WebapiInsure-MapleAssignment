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
    public class ProcedureController : ControllerBase
    {
        Repositories.IDataAccess<Insert_Contract_Post_Method_API, string> _procrepo;
        public ProcedureController(Repositories.IDataAccess<Insert_Contract_Post_Method_API, string> b)
        {
            _procrepo = b;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Insert_Contract_Post_Method_API b)
        {
            int res = _procrepo.Addcontractwithproccall(b);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        }
    }
}
