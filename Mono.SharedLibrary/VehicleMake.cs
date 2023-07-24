using System.Text.Json.Serialization;

namespace Mono.SharedLibrary
{
    public class VehicleMake
    {
        public VehicleMake()
        {
            VehicleModels = new HashSet<VehicleModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abrv { get; set; } = string.Empty;

        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}