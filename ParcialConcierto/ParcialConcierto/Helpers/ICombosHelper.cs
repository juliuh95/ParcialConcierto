using Microsoft.AspNetCore.Mvc.Rendering;

namespace ParcialConcierto.Helpers
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboEntrancesAsync(int id);
    }
}
