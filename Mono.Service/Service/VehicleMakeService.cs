using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mono.Service.MonoDbContext;
using Mono.Service.Services.Interfaces;
using Mono.SharedLibrary;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.NetworkInformation;

namespace Mono.Service.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly MonoContext _monoContext;
        private readonly IMapper _mapper;

        public VehicleMakeService(IMapper mapper,
            MonoContext monoContext)
        {
            _mapper = mapper;
            _monoContext = monoContext;
        }
        public async Task CreateVehicleMake(VehicleMake vehicleMake)
        {
            await _monoContext.VehicleMakes.AddAsync(vehicleMake);
            await _monoContext.SaveChangesAsync();
        }

        public async Task DeleteVehicleMake(int id)
        {
            VehicleMake? vehicleMake = await _monoContext.VehicleMakes.FirstOrDefaultAsync(a => a.Id == id);

            if(vehicleMake != null)
            {
                _monoContext.VehicleMakes.Remove(vehicleMake);
                await _monoContext.SaveChangesAsync();
            }
        }

        public async Task<List<VehicleMakeViewModel>> GetAllVehicleMakes()
        {
            List<VehicleMake> vehicleMakes = await _monoContext.VehicleMakes.Include(a => a.VehicleModels).ToListAsync();

            return _mapper.Map<List<VehicleMakeViewModel>>(vehicleMakes);
        }

        public async Task<VehicleMakeViewModel> GetVehicleMake(int id)
        {
            VehicleMake? vehicleMake = await _monoContext.VehicleMakes.Include(a => a.VehicleModels).FirstOrDefaultAsync(a => a.Id == id);

            return _mapper.Map<VehicleMakeViewModel>(vehicleMake);
        }

        public async Task<List<VehicleMakeViewModel>> PagingVehicleMakes(Paging paging)
        {
            IQueryable<VehicleMake> pagedVehicleMakes = _monoContext.VehicleMakes.Include(a => a.VehicleModels)
                .Skip(paging.PageSize * paging.CurrentPage)
                .Take(paging.PageSize)
                .Where(a => a.Name.Contains(paging.Filter));

            if(paging.OrderBy == "asc")
            {
                pagedVehicleMakes.OrderBy(a => a.Name);
            }
            else
            {
                pagedVehicleMakes.OrderByDescending(a => a.Name);
            }

            await pagedVehicleMakes.ToListAsync();

            return _mapper.Map<List<VehicleMakeViewModel>>(pagedVehicleMakes);
        }

        public async Task UpdateVehicleMake(VehicleMake vehicleMake)
        {
            _monoContext.VehicleMakes.Update(vehicleMake);

            await _monoContext.SaveChangesAsync();
        }
    }
}
