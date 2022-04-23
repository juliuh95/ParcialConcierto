using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ParcialConcierto.Models
{
    public class TicketViewModel
    {
        [Display(Name = "Id del Ticket")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
 
        public int Id { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Entrada")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar una Entrada.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int EntranceId { get; set; }

        public IEnumerable<SelectListItem>? Entrances { get; set; }
    }
}
