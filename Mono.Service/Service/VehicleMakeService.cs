using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mono.Service.Interfaces;
using Mono.Service.MonoDbContext;
using Mono.SharedLibrary;

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
        public async Task CreateVehicleMake(VehicleMakeViewModel vehicleMakeViewModel)
        {
            VehicleMake vehicleMake = _mapper.Map<VehicleMake>(vehicleMakeViewModel);

            await _monoContext.VehicleMakes.AddAsync(vehicleMake);
            await _monoContext.SaveChangesAsync();
        }

        public async Task DeleteVehicleMake(int id)
        {
            VehicleMake? vehicleMake = await _monoContext.VehicleMakes.FirstOrDefaultAsync(a => a.Id == id);

            if (vehicleMake != null)
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

        public async Task<List<VehicleMakeViewModel>> PagingVehicleMakes(OrderAndSort paging)
        {
            IQueryable<VehicleMake> pagedVehicleMakes = _monoContext.VehicleMakes.Include(a => a.VehicleModels)
                .Where(a => a.Name.Contains(paging.Filter));

            IEnumerable<VehicleMake> list = await paging.Order(pagedVehicleMakes);

            list = list.ToList();

            return _mapper.Map<List<VehicleMakeViewModel>>(list);
        }

        public async Task UpdateVehicleMake(VehicleMakeViewModel vehicleMakeViewModel)
        {
            VehicleMake vehicleMake = _mapper.Map<VehicleMake>(vehicleMakeViewModel);

            _monoContext.VehicleMakes.Update(vehicleMake);
            await _monoContext.SaveChangesAsync();
        }
    }
}
