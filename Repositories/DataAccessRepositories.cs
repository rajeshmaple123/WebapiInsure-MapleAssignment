using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapiInsurer.Models;
using webapiInsurer.Controllers;
using System.Web.UI;
using System.Net;
using System.Net.Http;




using webapiInsurer;
using static webapiInsurer.Models.ApplicationContext;
using Microsoft.EntityFrameworkCore;

namespace webapiInsurer.Repositories
{
    public interface IDataAccess<TEntity, U> where TEntity : class
    {
        IEnumerable<TEntity> GetContracts();
        TEntity GetContract(U custname);
        int AddContract(TEntity b);
        int UpdateContract(U custname, TEntity b);
        int DeleteContract(U custname);
    }



    public class DataAccessRepository : IDataAccess<Contracts, string>
    {
        readonly ApplicationContext ctx;
        public DataAccessRepository(ApplicationContext c)
        {
            ctx = c;
        }
        public int AddContract(Contracts b)
        {
            ctx.Contracts.Add(b);
            int res = ctx.SaveChanges();
            return res;
        }

        public int DeleteContract(string custname)
        {
            int res = 0;
            var contract = ctx.Contracts.FirstOrDefault(b => b.CustomerName == custname);
            if (contract != null)
            {
                ctx.Contracts.Remove(contract);
                res = ctx.SaveChanges();
            }
            return res;
        }
        public Contracts GetContract(string custname)
        {
            var contract = ctx.Contracts.FirstOrDefault(b => b.CustomerName == custname);
            return contract;
        }

        public IEnumerable<Contracts> GetContracts()
        {
            var contract = ctx.Contracts.ToList();
            return contract;
        }

   
        public int UpdateContract(string CustomerName, string CustomerCountry, string coverageplan , Contracts b)
        {
            throw new NotImplementedException();
        }

        public int UpdateContract(Contracts b)
        {
            throw new NotImplementedException();
        }

        public int UpdateContract(string CustomerName, Contracts b)
        {
            int res = 0;
            var contracts = ctx.Contracts.Find(CustomerName);
            if (contracts != null)
            {
                contracts.CustomerName = b.CustomerName;
                contracts.CustomerCountry = b.CustomerCountry;
                contracts.CustomerAddress = b.CustomerAddress;
                contracts.CustomerGender = b.CustomerGender;
                contracts.CustomerCountry = b.CustomerCountry;
                contracts.CustomerDateofbirth = b.CustomerDateofbirth;
                contracts.SaleDate = b.SaleDate;
                contracts.NetPrice = b.NetPrice;
                contracts.CoveragePlan = b.CoveragePlan;
                res = ctx.SaveChanges();
            }
            return res;
        }


    }
}
