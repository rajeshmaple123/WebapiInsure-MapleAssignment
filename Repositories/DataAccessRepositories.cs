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
using System.Runtime.InteropServices.ComTypes;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace webapiInsurer.Repositories
{
    public interface IDataAccess<TEntity, U> where TEntity : class
    {
        IEnumerable<TEntity> GetContracts();
        TEntity GetContract(U custname);
        int AddContract(TEntity b);
        int UpdateContract(U custname, TEntity b);
        int DeleteContract(U custname);

        int Addcontractwithproccall(TEntity b);

        int Updatecontractwithproccall(TEntity b,U Custname);
    }

        public class DataAccessRepository : IDataAccess<Contracts, string>,IDataAccess<Insert_Contract_Post_Method_API,string>, IDataAccess<Update_Contract_PUT_Method_API, string>
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

        public int AddContract(Insert_Contract_Post_Method_API b)
        {
            throw new NotImplementedException();
        }

        public int AddContract(Update_Contract_PUT_Method_API b)
        {
            throw new NotImplementedException();
        }

        public int Addcontractwithproccall(Insert_Contract_Post_Method_API b)
        {

            ctx.Database.ExecuteSqlCommand("EXEC Insert_Contract_Post_Method_API @Name,@Address,@dateofbirth, @gender, @saledate, @country",
                new SqlParameter("@Name", b.Name),
                 new SqlParameter("@Address", b.Address),
                 new SqlParameter("@dateofbirth", b.Dateofbirth),
                 new SqlParameter("@gender", b.Gender),
                 new SqlParameter("@saledate", b.Saledate),
                 new SqlParameter("@country", b.Country));
     
            int res = ctx.SaveChanges();
            ctx.Inscon.Add(b);
            return res;
        }

        public int Addcontractwithproccall(Contracts b)
        {
            throw new NotImplementedException();
        }

        public int Addcontractwithproccall(Update_Contract_PUT_Method_API b)
        {
            throw new NotImplementedException();
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
                contracts.CustomerDateofbirth = b.CustomerDateofbirth;
                contracts.SaleDate = b.SaleDate;
                res = ctx.SaveChanges();
            }

            return res;
        }

        public int UpdateContract(string custname, Insert_Contract_Post_Method_API b)
        {
            throw new NotImplementedException();
        }

        public int UpdateContract(string custname, Update_Contract_PUT_Method_API b)
        {
            throw new NotImplementedException();
        }

        public int Updatecontractwithproccall(Contracts b)
        {
            throw new NotImplementedException();
        }

        public int Updatecontractwithproccall(Insert_Contract_Post_Method_API b,Contracts b1)
        {
            throw new NotImplementedException();
        }

        public int Updatecontractwithproccall(Insert_Contract_Post_Method_API b)
        {
            throw new NotImplementedException();
        }

        public int Updatecontractwithproccall(Insert_Contract_Post_Method_API b, string Custname)
        {
            throw new NotImplementedException();
        }

        public int Updatecontractwithproccall(Contracts b, string Custname)
        {
            throw new NotImplementedException();
        }

        public int Updatecontractwithproccall(Update_Contract_PUT_Method_API b, string Custname)
        {
           // var contracts = ctx.Contracts.Find(Custname);
           
                _ = ctx.Contracts.Find(Custname);
                ctx.Database.ExecuteSqlCommand("EXEC Update_Contract_PUT_Method_API @Name,@Address,@dateofbirth, @gender, @saledate, @country",
                    new SqlParameter("@Name", b.Name),
                  new SqlParameter("@Address", b.Address),
                  new SqlParameter("@dateofbirth", b.Dateofbirth),
                  new SqlParameter("@gender", b.Gender),
                  new SqlParameter("@saledate", b.Saledate),
                  new SqlParameter("@country", b.Country));
            

            int res = ctx.SaveChanges();
       
            return res;
        }

        Insert_Contract_Post_Method_API IDataAccess<Insert_Contract_Post_Method_API, string>.GetContract(string custname)
        {
            throw new NotImplementedException();
        }

        Update_Contract_PUT_Method_API IDataAccess<Update_Contract_PUT_Method_API, string>.GetContract(string custname)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Insert_Contract_Post_Method_API> IDataAccess<Insert_Contract_Post_Method_API, string>.GetContracts()
        {
            throw new NotImplementedException();

        }

        IEnumerable<Update_Contract_PUT_Method_API> IDataAccess<Update_Contract_PUT_Method_API, string>.GetContracts()
        {
            throw new NotImplementedException();
        }
    }
}
