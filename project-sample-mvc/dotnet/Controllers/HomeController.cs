using Microsoft.AspNetCore.Mvc;

namespace Covid
{
    public class HomeController : Controller
    {
        private readonly CovidDAL _covidDAL;

        public HomeController()
        {
            _covidDAL = new CovidDAL();
        }

        public IActionResult Index()
        {
            var model = _covidDAL.GetCasesForCountryByStatus("south-africa", "active");
            var viewModel = new ActiveCasesViewModel(model);

            return View(viewModel);
        }
    }
}
