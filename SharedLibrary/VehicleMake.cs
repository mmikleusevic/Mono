namespace Mono.SharedLibrary
{
    public class VehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abrv { get; set; } = string.Empty;

        public ICollection<VehicleModel>? VehicleModels { get; set; }
    }
}