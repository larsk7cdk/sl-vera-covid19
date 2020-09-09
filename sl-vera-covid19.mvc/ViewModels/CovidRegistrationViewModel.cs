using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace sl_vera_covid19.mvc.ViewModels
{
    public class CovidRegistrationViewModel
    {
        public string Id { get; set; }

        [DisplayName("CPR")]
        [Required(ErrorMessage = "Feltet er påkrævet")]
        public string Cpr { get; set; }

        [DisplayName("Navn")]
        [Required(ErrorMessage = "Feltet er påkrævet")]
        public string Name { get; set; }

        [DisplayName("Registreringsdato")]
        [Required(ErrorMessage = "Feltet er påkrævet")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Resultat")] 
        public bool Result { get; set; }
    }
}