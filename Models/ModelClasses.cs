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
        //[Required(ErrorMessage = "Please provide CustomerName ")]
        //[StringLength(100, MinimumLength = 2, ErrorMessage = "Length must be within 2 to 34 characters")]
        public string CustomerAddress { get; set; }
        //[Required(ErrorMessage = "CustomerAddress  is must")]
        //[StringLength(100, MinimumLength = 2, ErrorMessage = "Must be with 2 to 100 characters")]
        public string CustomerGender { get; set; }
        public string CustomerCountry { get; set; }
        //[Required(ErrorMessage = "Country is must")]

        public DateTime CustomerDateofbirth { get; set; }

        public DateTime SaleDate { get; set; }

        public string CoveragePlan { get; set; }
        public int NetPrice { get; set; }


      


    }
}
