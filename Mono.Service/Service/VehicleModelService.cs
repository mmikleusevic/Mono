﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mono.Service.MonoDbContext;
using Mono.Service.Services.Interfaces;
using Mono.SharedLibrary;

namespace Mono.Service.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class VehicleModelService : IVehicleModelService
    {
        private readonly MonoContext _monoContext;
        private readonly IMapper _mapper;

        public VehicleModelService(IMapper mapper,
            MonoContext monoContext)
        {
            _mapper = mapper;
            _monoContext = monoContext;
        }
        public async Task CreateVehicleModel(VehicleModel vehicleModel)
        {
            await _monoContext.VehicleModels.AddAsync(vehicleModel);
            await _monoContext.SaveChangesAsync();
        }

        public async Task DeleteVehicleModel(int id)
        {
            VehicleModel? vehicleModel = await _monoContext.VehicleModels.FirstOrDefaultAsync(a => a.Id == id);

            if (vehicleModel != null)
            {
                _monoContext.VehicleModels.Remove(vehicleModel);
                await _monoContext.SaveChangesAsync();
            }
        }

        public async Task<List<VehicleModelViewModel>> GetAllVehicleModels()
        {
            List<VehicleModel> vehicleModels = await _monoContext.VehicleModels.Include(a => a.VehicleMake).ToListAsync();

            return _mapper.Map<List<VehicleModelViewModel>>(vehicleModels);
        }

        public async Task<VehicleModelViewModel> GetVehicleModel(int id)
        {
            VehicleModel? vehicleModel = await _monoContext.VehicleModels.Include(a => a.VehicleMake)
                .FirstOrDefaultAsync(a => a.Id == id);

            return _mapper.Map<VehicleModelViewModel>(vehicleModel);
        }

        public async Task<List<VehicleModelViewModel>> PagingVehicleModels(Paging paging)
        {
            IQueryable<VehicleModel> pagedVehicleModels = _monoContext.VehicleModels.Include(a => a.VehicleMake)
                .Skip(paging.PageSize * paging.CurrentPage)
                .Take(paging.PageSize)
                .Where(a => a.Name.Contains(paging.Filter));

            if (paging.OrderBy == "asc")
            {
                pagedVehicleModels.OrderBy(a => a.Name);
            }
            else
            {
                pagedVehicleModels.OrderByDescending(a => a.Name);
            }

            await pagedVehicleModels.ToListAsync();

            return _mapper.Map<List<VehicleModelViewModel>>(pagedVehicleModels);
        }

        public async Task UpdateVehicleModel(VehicleModel vehicleModel)
        {
            _monoContext.VehicleModels.Update(vehicleModel);

            await _monoContext.SaveChangesAsync();
        }
    }
}