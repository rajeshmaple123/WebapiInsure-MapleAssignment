using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapiInsurer.Models;

namespace webapiInsurer.Controllers
{
    [Route("api/[controller]")]
   
    public class ContractController : Controller
    {
        Repositories.IDataAccess<Contracts, string> _contractrepo;
        public ContractController(Repositories.IDataAccess<Contracts, string >b)
        {
            _contractrepo = b;
        }
        
        // GET:https://localhost:44358/api/contract/ //
        [HttpGet] public IEnumerable<Contracts> Get()
        {
            var contract = _contractrepo.GetContracts();
            return contract;
        }

        // GET with parameter https://localhost:44358/api/contract/John
        [HttpGet("{custname}")]
        [Route("GetContract")]
        public IActionResult Get(string custname)
        {
            var contract = _contractrepo.GetContract(custname);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contract);
        }

        // POST api/values : https://localhost:44358/api/contract (Insert values in the body content type: /application/json)
        [HttpPost]  public IActionResult Post([FromBody] Contracts b)
        {
            int res = _contractrepo.AddContract(b);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        }

        // PUT https://localhost:44358/api/contract/John
        [HttpPut("{CustomerName}")]
        [Route("UpdateContract")]
        public IActionResult Put([FromBody] Contracts b, string CustomerName)
        {
            if (CustomerName == b.CustomerName)
            {
                int res = _contractrepo.UpdateContract(CustomerName, b);
                if (res != 0)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            return NotFound();
        }

        // DELETE https://localhost:44358/api/contract/Helen
        [HttpDelete("{custname}")]
        [Route("DeleteContract")]
        public IActionResult Delete(string custname)
        {   
            int res = _contractrepo.DeleteContract(custname);
            if (res != 0)
            {
                return Ok();
            }
            return NotFound();
        }    
}
}
