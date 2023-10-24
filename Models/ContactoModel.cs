using System.ComponentModel.DataAnnotations;

namespace PracticaCrud_MisaelSarabia.Models
{
    public class ContactoModel
    {
        public int IdContacto { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Telefono es requerido")]
        public string Telefono { get; set; }

        public string? Correo { get; set; }

        [Required(ErrorMessage = "El campo Clave es requerido")]
        public string Clave { get; set; }
    }
}
