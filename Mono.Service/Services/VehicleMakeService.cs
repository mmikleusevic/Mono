using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mono.Service.MonoDbContext;
using Mono.Service.Services.Interfaces;
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
        public async Task CreateVehicleMake(VehicleMake vehicleMake)
        {
            await _monoContext.VehicleMakes.AddAsync(vehicleMake);
            await _monoContext.SaveChangesAsync();
        }

        public async Task DeleteVehicleMake(int id)
        {
            _monoContext.Remove(id);
            await _monoContext.SaveChangesAsync();
        }

        public async Task<List<VehicleMakeViewModel>> GetAllVehicleMakes()
        {
            List<VehicleMake> vehicleMakes = await _monoContext.VehicleMakes.ToListAsync();

            return _mapper.Map<List<VehicleMakeViewModel>>(vehicleMakes);
        }

        public async Task<VehicleMakeViewModel> GetVehicleMake(int id)
        {
            VehicleMake? vehicleMake = await _monoContext.VehicleMakes.FirstOrDefaultAsync(a => a.Id == id);

            return _mapper.Map<VehicleMakeViewModel>(vehicleMake);
        }

        public async Task UpdateVehicleMake(VehicleMake vehicleMake)
        {
            _monoContext.VehicleMakes.Update(vehicleMake);

            await _monoContext.SaveChangesAsync();
        }
    }
}
