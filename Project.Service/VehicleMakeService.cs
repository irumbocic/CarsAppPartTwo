using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
//using X.PagedList;
//using Service.PageSortFilter;
using System.Linq;
using Project.Repository;
using Project.Service.Common;
using Project.Model;
//using AutoMapper;
using Project.DAL.Entities;
using Project.Repository.Repository;
using Project.Model.Common;
using AutoMapper;
using Project.DAL;

namespace Project.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        public VehicleMakeRepository repository;
        private readonly IMapper mapper;

        public VehicleMakeService(VehicleMakeRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<VehicleMake>> FindAsync(string SearchString, string SortBy, int? queryPage)
        { 
            var makesList = await repository.FindAsync(SearchString, SortBy, queryPage);

            List<VehicleMake> listMapped = mapper.Map<List<VehicleMakeEntity>, List<VehicleMake>>(makesList);

            //var makesListMapped = mapper.Map<List<VehicleMake>>(makesList);

            return listMapped;
        }

        public async Task<VehicleMake> CreteAsync(VehicleMake newItem)
        {
            var newItemEntity = await repository.CreteAsync(mapper.Map<VehicleMakeEntity>(newItem));

            return mapper.Map<VehicleMake>(newItemEntity);
        }
        public async Task<VehicleMake> DeleteAsync(int id)
        {

            var deleteItem = repository.repository.context.VehicleMakes.FirstOrDefault(m => m.Id == id);
            return mapper.Map<VehicleMake>(await repository.DeleteAsync(deleteItem.Id));

        }

        public async Task<VehicleMake> GetAsync(int id)
        {

            //var getItem = repository.repository.context.VehicleMakes.FirstOrDefault(m => m.Id == id);
            //return mapper.Map<VehicleMake>(await repository.GetAsync(getItem.Id));

            //var getItem = repository.GetAsync(id);
            return mapper.Map<VehicleMake>(await repository.GetAsync(id));

        }

        public async Task<VehicleMake> UpdateAsync(VehicleMake updatedItem)
        {
            var updatedItemEntity = await repository.UpdateAsync(mapper.Map<VehicleMakeEntity>(updatedItem));
            return mapper.Map<VehicleMake>(updatedItemEntity);
            


            //var item = repository.repository.context.VehicleMakes.Update(mapper.Map<VehicleMakeEntity>(updatedItem));

            //item.State = EntityState.Modified;

            //await repository.repository.context.SaveChangesAsync();

            //return updatedItem;


            //var existingItem = await repository.GetAsync((mapper.Map<VehicleMakeEntity>(updatedItem)).Id);

            //repository.repository.context.Update(existingItem);
            //repository.repository.context.SaveChanges();

            //return mapper.Map<VehicleMake>(existingItem);
        }

        public void Detach(VehicleMake item)
        {
            throw new NotImplementedException();
        }
    }
}
