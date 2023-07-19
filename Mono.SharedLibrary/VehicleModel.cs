namespace Mono.SharedLibrary
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abrv { get; set; } = string.Empty;

        public virtual VehicleMake VehicleMake { get; set; } = null!;
    }
}
