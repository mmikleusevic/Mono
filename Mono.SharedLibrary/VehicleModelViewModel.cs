using System.Text.Json.Serialization;

namespace Mono.SharedLibrary
{
    public class VehicleModelViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("MakeId")]
        public int MakeId { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("Abrv")]
        public string Abrv { get; set; } = string.Empty;
        [JsonPropertyName("VehicleMakeViewModel")]
        public VehicleMakeViewModel? VehicleMakeViewModel { get; set; }
    }
}
