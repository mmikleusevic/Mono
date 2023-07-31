using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mono.Service.Interfaces;
using Mono.Service.MonoDbContext;
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
        public async Task CreateVehicleModel(VehicleModelViewModel vehicleModelViewModel)
        {
            VehicleModel vehicleModel = _mapper.Map<VehicleModel>(vehicleModelViewModel);

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

        public async Task<List<VehicleModelViewModel>> PagingVehicleModels(OrderAndSort paging)
        {
            IQueryable<VehicleModel> pagedVehicleModels = _monoContext.VehicleModels.Include(a => a.VehicleMake)
                .Where(a => a.Name.Contains(paging.Filter));

            IEnumerable<VehicleModel> list = await paging.Order(pagedVehicleModels);

            list = list.ToList();

            return _mapper.Map<List<VehicleModelViewModel>>(list);
        }

        public async Task UpdateVehicleModel(VehicleModelViewModel vehicleModelViewModel)
        {
            VehicleModel vehicleModel = _mapper.Map<VehicleModel>(vehicleModelViewModel);

            _monoContext.VehicleModels.Update(vehicleModel);

            await _monoContext.SaveChangesAsync();
        }
    }
}
