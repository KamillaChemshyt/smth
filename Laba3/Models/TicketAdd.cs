using Laba3.Dal;
using Laba3.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba3.Models
{
    public class TicketAdd
    {
        public List<string> PassengerIds { get; set; }

        public List<string> AirlineIds { get; set; }

        public Ticket Ticket { get; set; }


    }
}