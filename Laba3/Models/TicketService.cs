using Laba3.Dal;
using Laba3.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba3.Models
{
    public class TicketService
    {
        protected readonly DbSet<Ticket> Set;

        protected readonly DatabaseContext Context;

        public TicketService(DatabaseContext context)
        {
            Context = context;
            Set = context.Set<Ticket>();
        }

        public async Task<Ticket> GetTicketByIdAsync(string id)
        {
            return await Set.FirstOrDefaultAsync(x => x.Ticket_Id.Equals(id));
        }


        public async Task AddTicketAsync(Ticket obj)
        {
            await Set.AddAsync(obj);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Ticket obj)
        {
            Set.Remove(obj);

            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ticket obj)
        {
            Set.Update(obj);

            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await Set.ToListAsync();
        }

        public IEnumerable<Ticket> GetPassengerTicketsAsync(string id)
        {
            return Set.Where(x => x.Passenger_Id.Equals(id));
        }

    }
}
