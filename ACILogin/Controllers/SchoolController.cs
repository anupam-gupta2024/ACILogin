using ACILogin.Services;
using Microsoft.AspNetCore.Mvc;

namespace ACILogin.Controllers
{
    public class SchoolController : baseController
    {
        public SchoolController(IDataService layer) : base(layer)
        {
        }

        public IActionResult Index()
        {
            _MoviesParam.Action = 1;
            ViewBag.Data = _layer.Movies(_MoviesParam);


            return View();
        }
    }
}
