using ParcialConcierto.Data.Entities;

namespace ParcialConcierto.Data
{
    public class SeedDb
    {

        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTicketsAsync();
            //await CheckEntrancesAsync();

        }

        /*private async Task CheckEntrancesAsync()
        {
            if (!_context.Entrances.Any())
            {
                _context.Entrances.Add(new Entrance { Description ="Norte" });
                _context.Entrances.Add(new Entrance { Description ="Sur" });
                _context.Entrances.Add(new Entrance { Description ="Oriental" });
                _context.Entrances.Add(new Entrance { Description ="Occidental" });
                await _context.SaveChangesAsync();
            }
        }*/

        private async Task CheckTicketsAsync()
        {
            if (!_context.Tickets.Any())

            {
                for (int i = 0; i < 5000; i++)
                {
                    _context.Tickets.Add(new Ticket { 
                        WasUsed = false, 
                        Document = "", 
                        Name = "",
                        Entrances = new List<Entrance>() { 
                            new Entrance() { Description ="Norte" },
                            new Entrance() { Description ="Sur" },
                            new Entrance() { Description ="Oriental" },
                            new Entrance() { Description ="Occidental" },}
                    });
                }
                
                await _context.SaveChangesAsync();
            }
        }
    }
}
