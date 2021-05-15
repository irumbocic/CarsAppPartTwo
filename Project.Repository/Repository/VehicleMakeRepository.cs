using AutoMapper;
using Project.DAL.Entities;
using Project.Model;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Project.Repository.Repository

{

    public class VehicleMakeRepository : IVehicleMakeRepository
    {

        public VehicleRepository<VehicleMakeEntity> repository;

        public VehicleMakeRepository(VehicleRepository<VehicleMakeEntity> repository)
        {
            this.repository = repository;
        }


        //public async Task<IPagedList<VehicleMake>> FindAsync(IFilterMake filter, ISortMake sort, IPaging<VehicleMake> paging)
        //{

        //    IQueryable<VehicleMake> VehicleMakeList = context.VehicleMakes;


        //    var listFilter = filter.Filtering(VehicleMakeList, filter);

        //    var sortMake = sort.Ordering(listFilter, sort);

        //    var pagedMake = await paging.PagingListAsync(sortMake);

        //    return pagedMake;
        //}


        public async Task<List<VehicleMakeEntity>> FindAsync(string SearhcString)
        {
            var query = (from makes
                         in repository.context.VehicleMakes
                         select makes);

            if (!string.IsNullOrEmpty(SearhcString))
            {
                query = query.Where(m => m.Name.Contains(SearhcString));
            }

            return await query.ToListAsync();
        }

        public async Task<VehicleMakeEntity> CreteAsync(VehicleMakeEntity newItem)
        {

            return await repository.CreteAsync(newItem);
        }
        public async Task<VehicleMakeEntity> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<VehicleMakeEntity> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<VehicleMakeEntity> UpdateAsync(VehicleMakeEntity updatedItem)
        {
            return await repository.UpdateAsync(updatedItem);
        }
    }
}
