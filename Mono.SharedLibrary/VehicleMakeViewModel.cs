using System.Text.Json.Serialization;

namespace Mono.SharedLibrary
{
    public class VehicleMakeViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("Abrv")]
        public string Abrv { get; set; } = string.Empty;
        [JsonPropertyName("VehicleModelViewModels")]
        public List<VehicleModelViewModel>? VehicleModelViewModels { get; set; }
    }
}
