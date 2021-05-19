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
    public class VehicleModelService : IVehicleModelService
    {
        private readonly VehicleModelRepository repository;
        private readonly IMapper mapper;

        public VehicleModelService(VehicleModelRepository repository, IMapper mapper, VehicleContext context)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        public async Task<List<VehicleModel>> FindAsync(string SearchString, string SortBy, int? queryPage)
        {
            var modelsList = await repository.FindAsync(SearchString, SortBy, queryPage);

            List<VehicleModel> listMapped = mapper.Map<List<VehicleModelEntity>, List<VehicleModel>>(modelsList);

            //var makesListMapped = mapper.Map<List<VehicleMake>>(makesList);

            return listMapped;
        }

        public async Task<VehicleModel> CreteAsync(VehicleModel newItem)
        {
            var newItemEntity = await repository.CreteAsync(mapper.Map<VehicleModelEntity>(newItem));

            return mapper.Map<VehicleModel>(newItemEntity);
        }
        public async Task<VehicleModel> DeleteAsync(int id)
        {

            var deleteItem = repository.repository.context.VehicleModels.FirstOrDefault(m => m.Id == id);
            return mapper.Map<VehicleModel>(await repository.DeleteAsync(deleteItem.Id));

        }

        public async Task<VehicleModel> GetAsync(int id)
        {

            var getItem = repository.repository.context.VehicleModels.FirstOrDefault(m => m.Id == id);
            return mapper.Map<VehicleModel>(await repository.GetAsync(getItem.Id));

        }

        public async Task<VehicleModel> UpdateAsync(VehicleModel updatedItem)
        {
            var updatedItemEntity = await repository.UpdateAsync(mapper.Map<VehicleModelEntity>(updatedItem));
            return mapper.Map<VehicleModel>(updatedItemEntity);
        }

    }
}
