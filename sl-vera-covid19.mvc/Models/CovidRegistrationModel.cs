using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace sl_vera_covid19.mvc.Models
{
    public class CovidRegistrationModel
    {
        [JsonProperty(PropertyName = "id")] 
        public string Id { get; set; }

        [JsonProperty(PropertyName = "cpr")]
        [DisplayName("CPR")]
        public string Cpr { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "registrationdate")]
        public DateTime RegistrationDate { get; set; }

        [JsonProperty(PropertyName = "result")]
        public bool Result { get; set; }
    }
}