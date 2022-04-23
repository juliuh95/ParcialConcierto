using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialConcierto.Data;
using ParcialConcierto.Data.Entities;
using ParcialConcierto.Helpers;
using ParcialConcierto.Models;
using System.Diagnostics;

namespace ParcialConcierto.Controllers
{
    public class TicketController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public TicketController(DataContext context, ICombosHelper combosHelper)
        {
            _combosHelper = combosHelper;
            _context = context;
        }
        public IActionResult IndexTicket()
        {
            return View();
        }

        public async Task<IActionResult> SearchTicket(int? id)
        {
            Debug.WriteLine("########" + id);
            if (id == null)
            {
                return NotFound();
            }
            Ticket ticket = await _context.Tickets
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null)
            {
                Debug.WriteLine("######## Entro al no encontro ticket");

                ModelState.AddModelError(string.Empty, "");


            }
            
            if (ticket.WasUsed)
            {
                Debug.WriteLine("######## Entro al details");
                return RedirectToAction(nameof(DetailsTicket), ticket);
            }
            else {
                Debug.WriteLine("######## Entro al else o sea que no esta usado");
                return RedirectToAction(nameof(TicketForm), ticket);
            }

            return View(ticket);

        }


        public async Task<IActionResult> TicketForm(int id)
        {
            Ticket ticket = await _context.Tickets
                .Include(t => t.Entrance)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null)
            {
                return NotFound();
            }
            TicketViewModel ticketViewModel = new()
            {
                Document = ticket.Document,
                Name = ticket.Name,
                Entrances = await _combosHelper.GetComboEntrancesAsync(ticket.Id),

            };
            return View(ticketViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> TicketForm(int id, TicketViewModel ticketViewModel)
        { 
            if (ModelState.IsValid) 
            {
                try
                {
                    Ticket ticket = new()
                    {
                        Id = ticketViewModel.Id,
                        WasUsed = true,
                        Document = ticketViewModel.Document,
                        Name = ticketViewModel.Name,
                        Date = DateTime.Now,
                        Entrance = await _context.Entrances.FindAsync(ticketViewModel.EntranceId),
                    };
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(IndexTicket));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(ticketViewModel);
        }

        public async Task<IActionResult> DetailsTicket(Ticket ticket1) 
        {
            if (ticket1.Id == null)
            {
                return NotFound();
            }
            Ticket ticket = await _context.Tickets
                .Include(t => t.Entrance)
                .FirstOrDefaultAsync(t => t.Id == ticket1.Id);

            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

    }
}

