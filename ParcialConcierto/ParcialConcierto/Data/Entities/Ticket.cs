using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ParcialConcierto.Data.Entities
{
    public class Ticket
    {
        [Display(Name = "Id del Ticket")]
        public int Id { get; set; }

        [Display(Name = "Boleto Usado")]        
       
        public bool WasUsed { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public Entrance? Entrance { get; set; }


        [Display(Name = "Fecha y Hora de la Entrada")]
        public DateTime? Date { get; set; }


    }
}
