using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba3.Dal.Entities
{
    [Table("Passenger")]
    public class Passenger
    {
        [Key]
        public string Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Passport_Number { get; set; }
    }
}