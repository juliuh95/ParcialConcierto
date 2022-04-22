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
                .Include(t => t.Entrances)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null)
            {
                return NotFound();
            }
            if (ticket.WasUsed)
            {
            }
            else {
                Debug.WriteLine("######## Entro al else o sea que no esta usado");
                return RedirectToAction(nameof(TicketForm), ticket);
            }

            return View(ticket);

        }
        public async Task<IActionResult> TicketForm(int id, Ticket ticket)
        {
            Debug.WriteLine("######## el id en ticket form es " + ticket.Id);
            TicketViewModel ticketViewModel = new()
            {
                Entrances = await _combosHelper.GetComboEntrancesAsync(ticket.Id),
            };
            Debug.WriteLine("########");
            return View(ticketViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> TicketForm(TicketViewModel ticketViewModel)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    Ticket ticket = new()
                    {
                        WasUsed = true,
                        Id = ticketViewModel.Id,
                        Document = ticketViewModel.Document,
                        Name = ticketViewModel.Name,
                        Date = DateTime.Now,

                    };
                    _context.Add(ticket);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(IndexTicket));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un país con el mismo nombre.");
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

    }
}

