using Project.DAL;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Repository
{
    public class VehicleRepository<T> : IVehicleRepository<T> where T: class
    {
        private readonly VehicleContext context;

        public VehicleRepository(VehicleContext context)
        {
            this.context = context;
        }


        public async Task<T> CreteAsync(T newItem)
        {
            await context.Set<T>().AddAsync(newItem);
            await context.SaveChangesAsync();
            return newItem;

        }
        public async Task<T> DeleteAsync(int id)
        {
            var deleteItem = await context.Set<T>().FindAsync(id);
            context.Remove(deleteItem);
            await context.SaveChangesAsync();
            return deleteItem;
        }

        public async Task<T> GetAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T updatedItem)
        {
            var item = context.Set<T>().Attach(updatedItem);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return updatedItem;

        }

    }
}
