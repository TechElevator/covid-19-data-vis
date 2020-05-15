using System.Collections.Generic;
using System.Linq;

namespace Covid
{
    public class ActiveCasesViewModel
    {
        public ActiveCasesViewModel(List<CovidCountryModel> model)
        {
            this.ActiveCaseCounts = model.Select(m => m.Active).ToList();
            this.ActiveCaseDates = model.Select(m => m.Date.ToString("MMM dd")).ToList();
        }

        public List<int> ActiveCaseCounts { get; set; }

        public List<string> ActiveCaseDates { get; set; }
    }
}

