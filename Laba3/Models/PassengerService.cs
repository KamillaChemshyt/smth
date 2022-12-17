using Laba3.Dal;
using Laba3.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba3.Models
{
    public class PassengerService
    {

        protected readonly DbSet<Passenger> Set;

        protected readonly DatabaseContext Context;

        public PassengerService(DatabaseContext context)
        {
            Context = context;
            Set = context.Set<Passenger>();
        }

        public async Task<Passenger> GetPassengerByIdAsync(string id)
        {
            return await Set.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Passenger> GetPassengerByLastNameAsync(string lastName)
        {
            return await Set.FirstOrDefaultAsync(x => x.Last_Name.Equals(lastName));
        }

        public async Task AddPassengerAsync(Passenger obj)
        {
            await Set.AddAsync(obj);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Passenger obj)
        {
            Set.Remove(obj);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Passenger obj)
        {
            Set.Update(obj);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Passenger>> GetAllAsync()
        {
            return await Set.ToListAsync();
        }

        public async Task<List<string>> GetAllPassengerIds()
        {
            return await Set.Select(x => x.Id).ToListAsync();
        }


    }


}
