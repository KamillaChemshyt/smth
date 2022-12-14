using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba3.Dal.Entities
{
    [Table("Airline")]
    public class Airline
    {
        [Key]
        public string Airline_Id { get; set; }

        public string Company_Name { get; set; }

    }
}
