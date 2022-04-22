using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParcialConcierto.Data;
using System.Diagnostics;

namespace ParcialConcierto.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboEntrancesAsync(int id)
        {
            Console.WriteLine("Llegue");
            Debug.WriteLine("Lleg");
            List<SelectListItem> list = await _context.Entrances
                .Select(c => new SelectListItem
            {
                Text = c.Description,
                Value = c.Id.ToString()
            })
               .OrderBy(c => c.Text)
               .ToListAsync();

            list.Insert(0, new SelectListItem { Text = "[Seleccione una entrada...", Value = "0" });
            return list;
        }
    }
}
