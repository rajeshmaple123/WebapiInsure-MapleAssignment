using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace webapiInsurer.Models
{
    public class Contracts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerCountry { get; set; }
        public DateTime CustomerDateofbirth { get; set; }
        public DateTime SaleDate { get; set; }
    }

    public class Insert_Contract_Post_Method_API
    {
        [Key]

        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Gender { get; set; }
        public DateTime? Saledate { get; set; }
        public string Country { get; set; }
    }

    public class Update_Contract_PUT_Method_API
    {
        [Key]

        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Gender { get; set; }
        public DateTime? Saledate { get; set; }
        public string Country { get; set; }
        public int  NetPrice { get; set; }
        public string CoveragePlan { get; set; }

    }

}
