using Newtonsoft.Json;

namespace sl_vera_covid19.mvc.Domains.DomainModels
{
    public class CovidRegistration
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
    }
}