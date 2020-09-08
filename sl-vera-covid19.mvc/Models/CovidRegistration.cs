using Newtonsoft.Json;

namespace sl_vera_covid19.mvc.Models
{
    public class CovidRegistration
    {
        [JsonProperty(PropertyName = "id")] 
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
    }
}