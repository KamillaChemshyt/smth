using Laba3.Dal;
using Laba3.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba3.Models
{
    public class AirlineService
    {
        protected readonly DbSet<Airline> Set;

        protected readonly DatabaseContext Context;

        public AirlineService(DatabaseContext context)
        {
            Context = context;
            Set = context.Set<Airline>();
        }

        public async Task<Airline> GetAirlineByIdAsync(string id)
        {
            return await Set.FirstOrDefaultAsync(x => x.Airline_Id.Equals(id));
        }

        public async Task AddAirlineAsync(Airline obj)
        {
            await Set.AddAsync(obj);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Airline obj)
        {
            Set.Remove(obj);

            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Airline obj)
        {
            Set.Update(obj);

            await Context.SaveChangesAsync();
        }
    }
}
