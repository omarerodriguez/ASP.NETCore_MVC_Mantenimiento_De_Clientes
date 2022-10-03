using System.ComponentModel.DataAnnotations;

namespace Mantemiento_ClientesMVC.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nombres Requerido")]
        [MaxLength(50)]
        public string Nombres { get; set; }
        [Required(ErrorMessage ="Apellidos Requerido")]
        [MaxLength(50)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage ="Direccion Requerida")]
        [MaxLength(100)]
        public string Direccion { get; set; }
        [Required(ErrorMessage ="Telefono Requerido")]
        public string Telefono { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}
