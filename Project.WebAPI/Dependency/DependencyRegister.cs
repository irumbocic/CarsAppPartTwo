using Autofac;
using AutoMapper;
using Project.DAL.Entities;
using Project.Model;
using Project.Repository.Repository;
using Project.Service;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebAPI.Dependency
{
    public class DependencyRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //base.Load(builder); 

            //builder.RegisterType<VehicleModelService>().As<IVehicleModelServiceSTARO>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleMakeRepository>();
            builder.RegisterGeneric(typeof(VehicleRepository<>))
                    //.As(typeof(IVehicleRepository<>))
                    .InstancePerLifetimeScope();

        }
    }
}
